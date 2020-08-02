using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WizDirector : MonoBehaviour
{
    public delegate void WizActive(bool active);
    public delegate void WizShoot(UnityEngine.Vector3 rot);
    public WizActive wizActive;
    public WizShoot wizShoot;

    private string lineNumbers;
    private WizDataBase wizDB;
    private CastArea castArea;
    private Player player;

    private void Awake()
    {
        wizDB = GameObject.Find("WizDB").GetComponent<WizDataBase>();
        castArea = GameObject.Find("CastArea").GetComponent<CastArea>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        lineNumbers = "9999999999";
    }

    public void WizDetector(int[] lines)
    {
        lineNumbers = Convert.ToString(lines[0]) + Convert.ToString(lines[1]) + Convert.ToString(lines[2]) + Convert.ToString(lines[3]) + Convert.ToString(lines[4]);
        //Debug.Log(lineNumbers);
        switch (lineNumbers)
        {
            /*case "03479":  // id : 99   ---  여기에 id
                StartCoroutine(castArea.DrawCast(2.5f));
                wizShoot = wizDB.wizPractice.WizRotate;
                wizActive = wizDB.wizPracticeGM.SetActive;
                break;*/

            case "36999999":  // id : 13
                StartCoroutine(castArea.DrawCast(1.2f));
                wizShoot = wizDB.wiz13.GetComponent<AimWiz>().WizRotate;
                wizShoot += player.wizRotateAnim;
                wizActive = wizDB.wiz13OB.SetActive;
                break;

            case "199999999": // id : 22
                StartCoroutine(castArea.DrawCast(0.7f));
                wizShoot = wizDB.wiz22.GetComponent<AimWiz>().WizRotate;
                wizShoot += player.wizRotateAnim;
                wizActive = wizDB.wiz22OB.SetActive;
                break;



            default:
                castArea.DrawInit();
                castArea.CastInit();
                break;
            // 이제 여기서 올바른 위즈를 판단해주고,
            // 적당한 위치(wiz 1, 2, 3 중 하나)에 그 위즈를 배정해주는 역할을 할거야
            // 조준이냐 범위냐 따라 다르게 행동하는 건 위즈 각자가 해야할 일이야
            //0.3  0.7  1.2  1.8  2.5
        }
    }
}