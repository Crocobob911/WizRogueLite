using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizDirector : MonoBehaviour
{
    public delegate void WizDelegate();
    public WizDelegate wizActive;
    public GameObject wizOnEditGM;

    private string lineNumbers;
    private int wizOnEditNum;
    private GameObject[] wizGameObjects = new GameObject[3];
    private WizDataBase wizDB;
    private CastArea castArea;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            wizGameObjects[i] = transform.GetChild(i).gameObject;
        }
        wizDB = GameObject.Find("WizDB").GetComponent<WizDataBase>();
        castArea = GameObject.Find("CastArea").GetComponent<CastArea>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        lineNumbers = "9999999999";
        wizOnEditNum = 0;
    }

    public void WizDetector(int[] lines)
    {
        lineNumbers = Convert.ToString(lines[0]) + Convert.ToString(lines[1]) + Convert.ToString(lines[2]) + Convert.ToString(lines[3]) + Convert.ToString(lines[4]);
        Debug.Log(lineNumbers);
        switch (lineNumbers)
        {
            case "03479":  // id : 99   ---  여기에 id
                WizObjectManager();
                wizOnEditGM.AddComponent<WizProjectilePrac>();
                StartCoroutine(castArea.DrawCast(wizDB.WizPractice.wizCastTime));
                wizActive = wizDB.WizPractice.WizActive;
                break;


            default:
                castArea.DrawInit();
                castArea.CastInit();
                break;
            // 이제 여기서 올바른 위즈를 판단해주고,
            // 적당한 위치(wiz 1, 2, 3 중 하나)에 그 위즈를 배정해주는 역할을 할거야
            // 조준이냐 범위냐 따라 다르게 행동하는 건 위즈 각자가 해야할 일이야
        }
    }

    private void WizObjectManager()
    {
        if (wizOnEditNum == 0)
            wizOnEditGM = wizGameObjects[0];

        else if (wizOnEditNum == 1)
            wizOnEditGM = wizGameObjects[1];

        else if (wizOnEditNum == 2)
            wizOnEditGM = wizGameObjects[2];

        wizOnEditNum++;

    }
}