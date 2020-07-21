using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingJoystick : MonoBehaviour
{
    public Canvas can;
    public Vector3 joyMov;
    public bool isMoving;
    public float jSRadius;

    private GameObject mJSBack; //moving Joy Stick의 약자
    private GameObject mJStick;
    private Vector3 stickFirstPos;
    private Vector3 stickStartPos;
    private Vector3 stickPos;
    private Vector3 joyVec;
    private Vector3 joyRot;

    void Start()
    {
        Init();

    }

    private void Init()
    {
        mJSBack = GameObject.Find("MovingJoyStickBack");
        mJStick = GameObject.Find("MovingJoyStick");

        jSRadius = mJSBack.GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        stickFirstPos = mJSBack.transform.position;
        float canSize = can.transform.GetComponent<RectTransform>().localScale.x;
        jSRadius *= canSize;
        stickStartPos = Vector3.zero;
        joyVec = Vector3.zero;
        joyVec = Vector3.zero;
        joyRot = Vector3.zero;
        joyMov = Vector3.zero;
        isMoving = false;

        mJSBack.SetActive(false);
        mJStick.SetActive(false);
    }

    public void MovingStart(BaseEventData _Data)
    {
        mJSBack.SetActive(true);
        mJStick.SetActive(true);
        PointerEventData Data = _Data as PointerEventData;
        stickStartPos = Data.position;
        mJSBack.transform.position = stickStartPos;
        mJStick.transform.position = stickStartPos;
        isMoving = true;

    }


    public void Moving(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        stickPos = Data.position;
        joyVec = stickPos - stickStartPos;
        joyRot = joyVec.normalized;

        float stickDis = Vector3.Distance(stickPos, stickStartPos);
        if (stickDis < jSRadius)
            joyMov = joyRot * stickDis / jSRadius;
        else
            joyMov = joyRot;
        

        mJStick.transform.position = stickStartPos + joyMov * jSRadius;
    }


    public void MovingEnd()
    {
        isMoving = false;
        mJSBack.transform.position = stickFirstPos;
        mJStick.transform.position = stickFirstPos;
        mJSBack.SetActive(false);
        mJStick.SetActive(false);
        joyVec = Vector3.zero;
        joyRot = Vector3.zero;
        joyMov = Vector3.zero;
    }



}
