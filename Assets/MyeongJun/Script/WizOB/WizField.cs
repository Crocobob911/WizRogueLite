using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WizField : WizController
{
    protected WizDirector wizDirector;

    protected override void WizAwake()
    {
        base.WizAwake();
        wizDirector = GameObject.Find("WizDirector").GetComponent<WizDirector>();
    }
}
