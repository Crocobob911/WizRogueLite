using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizDataBase : MonoBehaviour
{
    public Wiz01 wiz01;
    public Wiz13 wiz13;
    public Wiz14 wiz14;
    public Wiz22 wiz22;
    public Wiz25 wiz25;
    public Wiz33 wiz33;
    public Wiz43 wiz43;
    public Wiz44 wiz44;
    public Wiz46 wiz46;

    public GameObject wiz01OB;
    public GameObject wiz13OB;
    public GameObject wiz14OB;
    public GameObject wiz22OB;
    public GameObject wiz25OB;
    public GameObject wiz33OB;
    public GameObject wiz43OB;
    public GameObject wiz44OB;
    public GameObject wiz46OB;

    public GameObject wiz01Area;
    public GameObject wiz13Area;
    public GameObject wiz14Area;
    public GameObject wiz22Area;
    public GameObject wiz25Area;
    public GameObject wiz33Area;
    public GameObject wiz43Area;
    public GameObject wiz44Area;
    public GameObject wiz46Area;

    private void Awake()
    {
        WizLoad();
    }

    private void Start()
    {
        WizLoadDone();
    }

    private void WizLoad()
    {
        wiz01OB = GameObject.Find("Wiz01").transform.GetChild(0).gameObject;
        wiz13OB = GameObject.Find("Wiz13").transform.GetChild(0).gameObject;
        wiz14OB = GameObject.Find("Wiz14").transform.GetChild(0).gameObject;
        wiz22OB = GameObject.Find("Wiz22").transform.GetChild(0).gameObject;
        wiz25OB = GameObject.Find("Wiz25").transform.GetChild(0).gameObject;
        wiz33OB = GameObject.Find("Wiz33").transform.GetChild(0).gameObject;
        wiz43OB = GameObject.Find("Wiz43").transform.GetChild(0).gameObject;
        wiz44OB = GameObject.Find("Wiz44").transform.GetChild(0).gameObject;
        wiz46OB = GameObject.Find("Wiz46").transform.GetChild(0).gameObject;

        wiz01Area = GameObject.Find("Wiz01").transform.GetChild(1).gameObject;
        wiz13Area = GameObject.Find("Wiz13").transform.GetChild(1).gameObject;
        wiz14Area = GameObject.Find("Wiz14").transform.GetChild(1).gameObject;
        wiz22Area = GameObject.Find("Wiz22").transform.GetChild(1).gameObject;
        wiz25Area = GameObject.Find("Wiz25").transform.GetChild(1).gameObject;
        wiz33Area = GameObject.Find("Wiz33").transform.GetChild(1).gameObject;
        wiz43Area = GameObject.Find("Wiz43").transform.GetChild(1).gameObject;
        wiz44Area = GameObject.Find("Wiz44").transform.GetChild(1).gameObject;
        wiz46Area = GameObject.Find("Wiz46").transform.GetChild(1).gameObject;

        wiz01 = GameObject.Find("Wiz01").GetComponent<Wiz01>();
        wiz13 = GameObject.Find("Wiz13").GetComponent<Wiz13>();
        wiz14 = GameObject.Find("Wiz14").GetComponent<Wiz14>();
        wiz22 = GameObject.Find("Wiz22").GetComponent<Wiz22>();
        wiz25 = GameObject.Find("Wiz25").GetComponent<Wiz25>();
        wiz33 = GameObject.Find("Wiz33").GetComponent<Wiz33>();
        wiz43 = GameObject.Find("Wiz43").GetComponent<Wiz43>();
        wiz44 = GameObject.Find("Wiz44").GetComponent<Wiz44>();
        wiz46 = GameObject.Find("Wiz46").GetComponent<Wiz46>();
    }

    private void WizLoadDone()
    {
        wiz01OB.SetActive(false);
        wiz13OB.SetActive(false);
        wiz14OB.SetActive(false);
        wiz22OB.SetActive(false);
        wiz25OB.SetActive(false);
        wiz33OB.SetActive(false);
        wiz43OB.SetActive(false);
        wiz44OB.SetActive(false);
        wiz46OB.SetActive(false);

        wiz01Area.SetActive(false);
        wiz13Area.SetActive(false);
        wiz14Area.SetActive(false);
        wiz22Area.SetActive(false);
        wiz25Area.SetActive(false);
        wiz33Area.SetActive(false);
        wiz43Area.SetActive(false);
        wiz44Area.SetActive(false);
        wiz46Area.SetActive(false);
    }
}
