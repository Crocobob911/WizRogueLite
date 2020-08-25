using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class WizDirector : MonoBehaviour
{
    public delegate void WizAreaRotate (UnityEngine.Vector3 rot);
    public delegate void WizReady(bool active);
    public delegate void WizActive(bool active);
    public delegate void WizShoot(UnityEngine.Vector3 rot);
    public WizAreaRotate wizAreaRotate;
    public WizReady wizReady;
    public WizActive wizActive;
    public WizShoot wizShoot;
    public GameObject areaOnEdit;
    public bool wizOn;

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
        wizOn = false;
        lineNumbers = "9999999999";
    }

    private void Update()
    {
        if (wizOn)
            StopCoroutine("DefaultWizReady");
        else
            StartCoroutine("DefaultWizReady");
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

            case "69999999": // id : 13
                wizOn = true;
                castArea.aimStick.SetActive(false);
                wizReady = wizDB.wiz13OB.SetActive;
                StartCoroutine(castArea.DrawCast(1.2f));
                areaOnEdit = wizDB.wiz13Area;
                areaOnEdit.SetActive(true);
                break;

            case "36999999":  // id : 14
                wizOn = true;
                castArea.aimStick.SetActive(false);
                wizReady = castArea.aimStick.SetActive;
                StartCoroutine(castArea.DrawCast(1.2f));
                areaOnEdit = wizDB.wiz14Area;
                wizAreaRotate = areaOnEdit.GetComponent<AreaProjectile>().AreaRotate;
                wizShoot = wizDB.wiz14.GetComponent<AimWiz>().WizRotate;
                wizShoot += player.wizRotateAnim;
                wizActive = wizDB.wiz14OB.SetActive;
                break;

            case "199999999": // id : 22
                wizOn = true;
                castArea.aimStick.SetActive(false);
                wizReady = castArea.aimStick.SetActive;
                StartCoroutine(castArea.DrawCast(0.7f));
                areaOnEdit = wizDB.wiz22Area;
                wizAreaRotate = areaOnEdit.GetComponent<AreaProjectile>().AreaRotate;
                wizShoot = wizDB.wiz22.GetComponent<AimWiz>().WizRotate;
                wizShoot += player.wizRotateAnim;
                wizActive = wizDB.wiz22OB.SetActive;
                break;

            case "4699999": // id : 25
                wizOn = true;
                castArea.aimStick.SetActive(false);
                wizReady = castArea.aimStick.SetActive;
                StartCoroutine(castArea.DrawCast(1.8f));
                areaOnEdit = wizDB.wiz25Area;
                wizAreaRotate = areaOnEdit.GetComponent<AreaProjectile>().AreaRotate;
                wizShoot = wizDB.wiz25.GetComponent<AimWiz>().WizRotate;
                wizShoot += player.wizRotateAnim;
                wizActive = wizDB.wiz25OB.SetActive;
                break;

            case "05999999": // id : 33
                wizOn = true;
                castArea.aimStick.SetActive(false);
                wizReady = wizDB.wiz33OB.SetActive;
                StartCoroutine(castArea.DrawCast(0.7f));
                areaOnEdit = wizDB.wiz33Area;
                areaOnEdit.SetActive(true);
                break;

            case "699999999": // id : 43
                wizOn = true;
                castArea.aimStick.SetActive(false);
                wizReady = castArea.aimStick.SetActive;
                StartCoroutine(castArea.DrawCast(0.7f));
                areaOnEdit = wizDB.wiz43Area;
                wizAreaRotate = areaOnEdit.GetComponent<AreaProjectile>().AreaRotate;
                wizShoot = wizDB.wiz43.GetComponent<AimWiz>().WizRotate;
                wizShoot += player.wizRotateAnim;
                wizActive = wizDB.wiz43OB.SetActive;
                break;

            case "5699999": // id : 44
                wizOn = true;
                castArea.aimStick.SetActive(false);
                wizReady = castArea.aimStick.SetActive;
                StartCoroutine(castArea.DrawCast(1.2f));
                areaOnEdit = wizDB.wiz44Area;
                wizAreaRotate = areaOnEdit.GetComponent<AreaProjectile>().AreaRotate;
                wizShoot = wizDB.wiz44.GetComponent<AimWiz>().WizRotate;
                wizShoot += player.wizRotateAnim;
                wizActive = wizDB.wiz44OB.SetActive;
                break;


            case "03479": // id : 46
                wizOn = true;
                castArea.aimStick.SetActive(false);
                wizReady = wizDB.wiz46OB.SetActive;
                StartCoroutine(castArea.DrawCast(2.5f));
                areaOnEdit = wizDB.wiz46Area;
                areaOnEdit.SetActive(true);
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

    private IEnumerator DefaultWizReady()
    {
        yield return new WaitForSeconds(1.5f);
        castArea.aimStick.SetActive(true);
        areaOnEdit = wizDB.wiz01Area;
        wizAreaRotate = areaOnEdit.GetComponent<AreaProjectile>().AreaRotate;
        wizShoot = wizDB.wiz01.GetComponent<AimWiz>().WizRotate;
        wizShoot += player.wizRotateAnim;
        wizActive = wizDB.wiz01OB.SetActive;
        wizOn = true;
    }

}