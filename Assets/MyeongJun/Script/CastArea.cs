using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class CastArea : MonoBehaviour
{
    public Canvas can;

    private int[] cast = new int[6];
    private int[] lineNumbers = new int[5];
    private int[] sortedLineNumbers = new int[5];
    private int[] lineId = new int[6];
    private GameObject[] lines = new GameObject[6];
    private List<CircleIdentifier> lCircles;
    //private List<CircleIdentifier> linesId;
    private Dictionary<int, CircleIdentifier> circles;
    private RectTransform lineOnEditRcTs;
    private CircleIdentifier circleOnEdit;
    private WizDirector wizDirector;

    private int firstCastNumber;
    private int castNumber;

    private bool drawing;
    private bool stopDrawing;
    private bool cancelDrawing;

    private GameObject lineOnEdit;
    private GameObject castArea;
    private GameObject castSpot;
    //private GameObject castDirectorGm;

    private void Awake()
    {
        lCircles = new List<CircleIdentifier>();
        circles = new Dictionary<int, CircleIdentifier>();
        //castDirectorGm = GameObject.Find("CastDirector");
        wizDirector = GameObject.Find("WizDirector").GetComponent<WizDirector>();
        castArea = GameObject.Find("CastArea");
        castSpot = GameObject.Find("CastSpot");
        for (int i = 0; i < 6; i++)
        {
            lines[i] = transform.GetChild(i + 3).gameObject;
        }
        for (int i = 0; i < 5; i++)
        {
            var circle = transform.GetChild(i + 9);
            var identifier = circle.GetComponent<CircleIdentifier>();
            identifier.id = i;
            circles.Add(i, identifier);
        }
    }
    void Start()
    {
        Init();
    }

    private void Init()
    {
        
        drawing = false;
        stopDrawing = false;
        lineOnEdit = null;
        lineOnEditRcTs = null;
        firstCastNumber = 6;
        castNumber = 0;
        foreach (var line in lines)
        {
            line.gameObject.SetActive(false);
        }
        for (int i = 0; i < 6; i++)
        {
            lineId[i] = 6;
        }
        for (int i = 0; i < 5; i++)
        {
            lineNumbers[i] = 99;
        }
        for (int i = 0; i < 5; i++)
        {
            sortedLineNumbers[i] = 99;
        }
        castSpot.SetActive(false);

        drawing = false;
        castNumber = 0;
        castArea.GetComponent<Image>().color = new Color(0, 0, 0, 50 / 255f);
        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;
        firstCastNumber = 6;
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
            Init();
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
            wizDirector.WizDectector(sortedLineNumbers);
            Init();
        }

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