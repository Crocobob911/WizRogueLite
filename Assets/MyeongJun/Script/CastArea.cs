using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class CastArea : MonoBehaviour
{
    public Canvas can;

    private int[] cast = new int[6];
    private int[] lineNumbers = new int[5];
    private int[] lineId = new int[6];
    private GameObject[] lines = new GameObject[6];
    private List<CircleIdentifier> lCircles;
    //private List<CircleIdentifier> linesId;
    private Dictionary<int, CircleIdentifier> circles;
    private RectTransform lineOnEditRcTs;
    private CircleIdentifier circleOnEdit;

    private int firstCastNumber;
    private int castNumber;
    private int touchCount;

    private bool drawing;
    private bool stopDrawing;

    private Vector3 touchPos;

    private GameObject lineOnEdit;
    private GameObject castArea;


    void Start()
    {
        //linesId = new List<CircleIdentifier>();
        lCircles = new List<CircleIdentifier>();
        circles = new Dictionary<int, CircleIdentifier>();
        castArea = GameObject.Find("CastArea");
        for(int i = 0;  i < 6; i++)
        {
            lines[i] = transform.GetChild(i + 8).gameObject;
        }
        for (int i = 0; i < 5; i++)
        {
            var circle = transform.GetChild(i + 2);
            var identifier = circle.GetComponent<CircleIdentifier>();
            identifier.id = i;
            circles.Add(i, identifier);
        }

        DrawingInit();
        Init();


     
    }

    private void DrawingInit()
    {
        drawing = false;
        stopDrawing = false;
        lineOnEdit = null;
        firstCastNumber = 6;
        castNumber = 0;
        for(int i = 0; i <6; i++)
        {
            lines[i].SetActive(false);
        }
    }

    private void Init()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (drawing)
        {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(touchPos, circleOnEdit.transform.position));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (touchPos - circleOnEdit.transform.position).normalized);
        }
    }

    public void OnTouchDownCircle(CircleIdentifier idf)
    {
        /*switch (Input.touchCount)
        {
            case 1:
                touchCount = 1;
                break;
            case 2:
                touchCount = 2;
                break;
            case 3:
                touchCount = 3;
                break;
            case 4:
                touchCount = 4;
                break;
            default:
                break;
        } //터치 수 판별기 - 터치 구별 용 */

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
        touchPos = circleOnEdit.transform.position;

        Debug.Log(circleOnEdit.transform.position + "시작점");
    }

    public void OnTouchDrag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        touchPos = Data.position;
    }

    public void OnTouchEnterCircle(CircleIdentifier idf)
    {
        Debug.Log(idf.id);
        if (drawing)
        {
            lineOnEditRcTs.sizeDelta = new Vector2(
                       lineOnEditRcTs.sizeDelta.x,
                       Vector3.Distance(circleOnEdit.transform.localPosition, idf.transform.localPosition));

            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (idf.transform.localPosition - circleOnEdit.transform.localPosition).normalized);

            TrySetLineEdit(idf);
        }

        
        
    }

    public void OnTouchUpCircle()
    {
        foreach(var line in lines)
                {
            line.gameObject.SetActive(false);
        }
        

        drawing = false;
        castNumber = 0;
        //castingBack.GetComponent<Image>().color = new Color(0, 0, 0, 50 / 255f);
        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;
        touchPos = Vector3.zero;
        firstCastNumber = 6;
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
        var lineIdf = line.AddComponent<CircleIdentifier>();
        lineIdf.id = id;
        lineId[castNumber] = id; 
        return line;
    }
}
