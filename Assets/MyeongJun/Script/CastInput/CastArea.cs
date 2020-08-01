using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CastArea : MonoBehaviour
{
    public Canvas can;
    public bool castDone;

    private int[] cast = new int[6];
    private int[] lineNumbers = new int[5];
    private int[] sortedLineNumbers = new int[5];
    private int[] lineId = new int[6];
    private GameObject[] loadingLines = new GameObject[5];

    private GameObject[] lines = new GameObject[6];
    private List<CircleIdentifier> lCircles;
    private Dictionary<int, CircleIdentifier> circles;
    private RectTransform lineOnEditRcTs;
    private RectTransform loadingLinesRcTs;
    private CircleIdentifier circleOnEdit;
    private WizDirector wizDirector;
    private Player player;

    private int firstCastNumber;
    private int castNumber;
    private int castLineCount;
    private float lineLength;

    private bool drawing;
    private bool stopDrawing;
    private bool cancelDrawing;

    private GameObject lineOnEdit;
    public GameObject castArea;
    private GameObject castSpot;
    private GameObject aimStick;

    private void Awake()
    {
        lCircles = new List<CircleIdentifier>();
        circles = new Dictionary<int, CircleIdentifier>();
        //castDirectorGm = GameObject.Find("CastDirector");
        wizDirector = GameObject.Find("WizDirector").GetComponent<WizDirector>();
        aimStick = GameObject.Find("AimStick");
        castArea = GameObject.Find("CastArea");
        castSpot = GameObject.Find("CastSpot");
        player = GameObject.Find("Player").GetComponent<Player>();
        for (int i = 0; i < 6; i++)
        {
            lines[i] = transform.GetChild(i + 2).gameObject;
        }
        for (int i = 0; i < 5; i++)
        {
            var circle = transform.GetChild(i + 8);
            var identifier = circle.GetComponent<CircleIdentifier>();
            identifier.id = i;
            circles.Add(i, identifier);

            loadingLines[i] = transform.GetChild(i + 14).gameObject;
        }
    }
    void Start()
    {
        DrawInit();
        CastInit();
    }

    public void DrawInit()
    {
        drawing = false;
        stopDrawing = false;
        lineOnEdit = null;
        lineOnEditRcTs = null;
        firstCastNumber = 6;
        for (int i = 0; i < 6; i++)
        {
            lineId[i] = 6;
            lines[i].SetActive(false);
        }
        for (int i = 0; i < 5; i++)
        {
            lineNumbers[i] = 99;
            sortedLineNumbers[i] = 99;
        }
        castSpot.SetActive(false);
        drawing = false;
        castArea.GetComponent<Image>().color = new Color(0, 0, 0, 50 / 255f);
        circleOnEdit = null;
        firstCastNumber = 6;
        
    }

    public void CastInit()
    {
        castDone = true;
        for(int i=0; i<5; i++)
        {
            loadingLinesRcTs = loadingLines[i].GetComponent<RectTransform>();
            loadingLinesRcTs.sizeDelta
                = new Vector2(loadingLinesRcTs.sizeDelta.x, 0f);
            loadingLines[i].SetActive(false);
        }
        for(int i=0; i<castNumber; i++)
        {
            lCircles[i].transform.GetChild(0).GetComponent<Image>().color
                = new Color(0, 0, 0, 1f);
        }
        castLineCount = 0;
        castNumber = 0;
        lCircles.Clear();
    }

    void Update()
    {
        if (drawing) //그리는 중
        {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(castSpot.transform.localPosition, circleOnEdit.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (castSpot.transform.localPosition - circleOnEdit.transform.localPosition).normalized);


            if (Vector3.Distance(castSpot.transform.localPosition  // 중앙에서 많이 벗어나면 드로잉 취소
                , Vector3.zero) > castArea.GetComponent<RectTransform>().sizeDelta.y)
            {
                cancelDrawing = true;
                castArea.GetComponent<Image>().color = new Color(150 / 255f, 0, 0, 50 / 255f);
            }
            else //다시 돌아오면
            {
                cancelDrawing = false;
                castArea.GetComponent<Image>().color = new Color(0, 0, 0, 50 / 255f);
            }
        }

    }

    public void OnTouchDownCircle(CircleIdentifier idf)
    {
        drawing = true;
        castDone = false;
        firstCastNumber = idf.id;
        for (int n = 0; n < 6; n++)
        {
            cast[n] = 6;
        }
        for (int i = 0; i < 5; i++)
        {
            lineNumbers[i] = 99;
        }
        TrySetLineEdit(idf);
        castSpot.SetActive(true);
        castSpot.transform.position = circleOnEdit.transform.position;
    }

    public void OnTouchDrag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        castSpot.transform.position = Data.position;
    }

    public void OnTouchEnterCircle(CircleIdentifier idf)
    {
        if (drawing)
        {
            lineOnEditRcTs.sizeDelta = new Vector2(
                       lineOnEditRcTs.sizeDelta.x,
                       Vector3.Distance(circleOnEdit.transform.localPosition, idf.transform.localPosition));

            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (idf.transform.localPosition - circleOnEdit.transform.localPosition).normalized);

            if (stopDrawing == false)
            {
                LineIdentifier(idf.id, circleOnEdit.id);
                TrySetLineEdit(idf);
            }

        }
    }

    public void OnTouchUpCircle()
    {
        if (cancelDrawing) //드로잉 취소
        {
            DrawInit();
            CastInit();
        }
        else //드로잉 완료
        {
            int temp;
            for (int n = 0; n < 5; n++)
            {
                sortedLineNumbers[n] = lineNumbers[n];
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (sortedLineNumbers[j] > sortedLineNumbers[j + 1])
                    {
                        temp = sortedLineNumbers[j];
                        sortedLineNumbers[j] = sortedLineNumbers[j + 1];
                        sortedLineNumbers[j + 1] = temp;
                    }
                }
            }
            wizDirector.WizDetector(sortedLineNumbers);
            DrawInit();
        }

    }

    public IEnumerator DrawCast(float time)
    {
        float lineSpeed = 0;
        for(int i = 0; i < castNumber -1; i++)
        {
            lineSpeed += Vector3.Distance(lCircles[castLineCount].transform.localPosition,
                lCircles[castLineCount + 1].transform.localPosition);
        }
        lineSpeed = lineSpeed * player.playerCastSpeed / time;


        while (castLineCount < castNumber - 1)
        {
            loadingLines[castLineCount].SetActive(true);
            lineLength = Vector3.Distance(lCircles[castLineCount].transform.localPosition,
                lCircles[castLineCount + 1].transform.localPosition);
            lCircles[castLineCount].transform.GetChild(0).GetComponent<Image>().color
                = new Color(1f, 0, 0, 1f);
            loadingLinesRcTs = loadingLines[castLineCount].GetComponent<RectTransform>();
            loadingLinesRcTs.localPosition = lCircles[castLineCount].gameObject.transform.localPosition;
            loadingLinesRcTs.rotation =
                Quaternion.FromToRotation(
                    Vector3.up,
                    (lCircles[castLineCount + 1].transform.localPosition - lCircles[castLineCount].transform.localPosition).normalized);

            while(loadingLinesRcTs.sizeDelta.y < lineLength)
            {
                loadingLinesRcTs.sizeDelta =
                    new Vector2(loadingLinesRcTs.sizeDelta.x,
                    loadingLinesRcTs.sizeDelta.y + lineSpeed * Time.deltaTime);

                if (loadingLinesRcTs.sizeDelta.y > lineLength)
                {
                    loadingLinesRcTs.sizeDelta
                    = new Vector3(loadingLinesRcTs.sizeDelta.x, lineLength, 0);
                }
                yield return new WaitForSeconds(0.01f);
            }
            lCircles[castLineCount+1].transform.GetChild(0).GetComponent<Image>().color
                = new Color(1f, 0, 0, 1f);

            castLineCount++;

        }

        yield return new WaitForSeconds(0.2f);
        aimStick.SetActive(true);
        CastInit();

    }

    private void TrySetLineEdit(CircleIdentifier circle)
    {
        foreach (var line in lineId)
        {
            if (line == circle.id)
            {
                if (firstCastNumber == circle.id && cast[2] != 6)
                {
                    stopDrawing = true;
                    continue;
                }
                return;
            }
        }
        lCircles.Add(circle);
        cast[castNumber] = circle.id;
        lineOnEdit = CreateLine(circle.transform.localPosition, circle.id);
        castNumber++;
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>();
        circleOnEdit = circle;
    }

    private GameObject CreateLine(Vector3 pos, int id)
    {
        var line = lines[castNumber];
        lines[castNumber].SetActive(true);
        line.transform.localPosition = pos;
        lineId[castNumber] = id;
        return line;
    }

    private void LineIdentifier(int a, int b)
    {
        if (a == b)
        {
            return;
        }
        if (a > b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        switch (a)
        {
            case 0:
                switch (b)
                {
                    case 1:
                        lineNumbers[castNumber - 1] = 0;
                        break;
                    case 2:
                        lineNumbers[castNumber - 1] = 1;
                        break;
                    case 3:
                        lineNumbers[castNumber - 1] = 2;
                        break;
                    case 4:
                        lineNumbers[castNumber - 1] = 3;
                        break;
                    default:
                        break;
                }
                break;

            case 1:
                switch (b)
                {
                    case 2:
                        lineNumbers[castNumber - 1] = 4;
                        break;
                    case 3:
                        lineNumbers[castNumber - 1] = 5;
                        break;
                    case 4:
                        lineNumbers[castNumber - 1] = 6;
                        break;
                    default:
                        break;
                }
                break;

            case 2:
                switch (b)
                {
                    case 3:
                        lineNumbers[castNumber - 1] = 7;
                        break;
                    case 4:
                        lineNumbers[castNumber - 1] = 8;
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch (b)
                {
                    case 4:
                        lineNumbers[castNumber - 1] = 9;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
}