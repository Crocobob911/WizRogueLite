using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizDataBase : MonoBehaviour
{
    public Wiz13 wiz13;
    public Wiz22 wiz22;

    public GameObject wiz13OB;
    public GameObject wiz22OB;

    private void Awake()
    {
        WizGameObjectLoad();
        WizComponentLoad();
    }

    private void Start()
    {
        WizLoadDone();
    }

    private void WizGameObjectLoad()
    {
        wiz13OB = GameObject.Find("Wiz13").transform.GetChild(0).gameObject;
        wiz22OB = GameObject.Find("Wiz22").transform.GetChild(0).gameObject;
    }

    private void WizComponentLoad()
    {
        wiz13 = GameObject.Find("Wiz13").GetComponent<Wiz13>();
        wiz22 = GameObject.Find("Wiz22").GetComponent<Wiz22>();

    }

    private void WizLoadDone()
    {
        wiz13OB.SetActive(false);
        wiz22OB.SetActive(false);
    }
}
