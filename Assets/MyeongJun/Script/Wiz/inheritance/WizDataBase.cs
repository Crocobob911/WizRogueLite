using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizDataBase : MonoBehaviour
{
    public WizProjectilePrac wizPractice;

    public GameObject wizPracticeGM;

    private void Awake()
    {
        WizGameObjectLoad();
        WizComponentLoad();
        WizLoadDone();
    }

    private void WizGameObjectLoad()
    {
        wizPracticeGM = GameObject.Find("WizPractice");
    }

    private void WizComponentLoad()
    {
        wizPractice = wizPracticeGM.GetComponent<WizProjectilePrac>();
    }

    private void WizLoadDone() {
        wizPracticeGM.SetActive(false);
    }
}
