using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingJoystick : MonoBehaviour
{
    public Vector3 joyMov;
    public bool isMoving;
    public float jSRadius;

    private GameObject mJSBack; //moving Joy Stick의 약자
    private GameObject mJStick;
    private GameObject mJStickGuide;
    private Vector3 stickFirstPos;
    private Vector3 stickStartPos;
    private Vector3 stickPos;
    private Vector3 joyVec;
    private Vector3 joyRot;

    private void Awake()
    {
        mJSBack = GameObject.Find("MovingJoyStickBack");
        mJStick = GameObject.Find("MovingJoyStick");
        mJStickGuide = GameObject.Find("MovingJoyStickGuide");
        jSRadius = GameObject.Find("MovingJoyStickBack").GetComponent<RectTransform>().sizeDelta.y
            * transform.parent.GetComponent<RectTransform>().localScale.x * 0.5f;
    }

    void Start()
    { 
        Init();
    }


    private void Init()
    {
        isMoving = false;
        mJSBack.transform.localPosition = Vector3.zero;
        mJStick.transform.localPosition = Vector3.zero;
        joyVec = Vector3.zero;
        joyRot = Vector3.zero;
        joyMov = Vector3.zero;
        stickStartPos = Vector3.zero;
        mJSBack.SetActive(false);
        mJStick.SetActive(false);
    }


    public void MovingStart(BaseEventData _Data)
    {
        mJSBack.SetActive(true);
        mJStick.SetActive(true);
        PointerEventData Data = _Data as PointerEventData;
        mJStickGuide.transform.position = Data.position;
        stickStartPos = mJStickGuide.transform.localPosition;
        mJSBack.transform.localPosition = stickStartPos;
        mJStick.transform.localPosition = Vector3.zero;
        isMoving = true;

    }


    public void Moving(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        mJStickGuide.transform.position = Data.position;
        stickPos = mJStickGuide.transform.localPosition;
        joyVec = stickPos - stickStartPos;
        joyRot = joyVec.normalized;

        float stickDis = Vector3.Distance(stickPos, stickStartPos);
        if (stickDis < jSRadius)
            joyMov = joyRot * stickDis / jSRadius;
        else
            joyMov = joyRot;

        mJStick.transform.localPosition = joyMov * jSRadius;
    }


    public void MovingEnd()
    {
        Init();
    }


}