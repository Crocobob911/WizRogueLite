﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WizAimStick : MonoBehaviour
{
    public GameObject aimStick;
    public Vector3 aimRot;

    private WizDirector wizDirector;
    private Vector3 stickPos;
    private Vector3 stickStartPos;
    private float aSRadius;
    private bool isAiming;
    private GameObject aimStickGuide;

    private void Awake()
    {
        wizDirector = GameObject.Find("WizDirector").GetComponent<WizDirector>();
        aimStickGuide = GameObject.Find("AimStickGuide");
        aimStick = GameObject.Find("AimStick");
        aSRadius = GameObject.Find("CastArea").GetComponent<RectTransform>().sizeDelta.y
            * transform.parent.GetComponent<RectTransform>().localScale.x * 0.5f;
        
    }

    void Start()
    {
        Init();
        Invoke("StickAwakeEnd", 0.05f);
    }

    private void Init()
    {
        isAiming = false;
        aimStick.transform.localPosition = Vector3.zero;
        aimRot = Vector3.zero;
        stickPos = Vector3.zero;
        stickStartPos = Vector3.zero;
    }

    public void AimingStart(BaseEventData _Data)
    {
        isAiming = true;
    }

    public void Aiming(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        aimStickGuide.transform.position = Data.position;
        stickPos = aimStickGuide.transform.localPosition;
        aimRot = (stickPos - stickStartPos).normalized;
        

        float stickDis = Vector3.Distance(stickPos, stickStartPos);
        if (stickDis < aSRadius)
            aimStick.transform.localPosition = aimRot * stickDis;
        else
            aimStick.transform.localPosition = aimRot * aSRadius;

        //Debug.Log(aimStick.transform.position);
    }

    public void AimingEnd()
    {
        wizDirector.wizActive(true);
        wizDirector.wizShoot(aimRot);
        Init();
        aimStick.SetActive(false);
    }

    private void StickAwakeEnd() //다른 코드에서 이 스틱을 불러오기 위한
    {                                              //시간을 잠시 벌어주기
        aimStick.SetActive(false);
    }
}
