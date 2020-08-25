using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWiz : Wiz
{
    protected WizAimStick wizAimStick;
    protected GameObject wizOnEdit;

    protected float effectSpeed;
    protected float destroyDistance;

    protected virtual void SetAimStick()
    {
        wizAimStick.aimStick.SetActive(true);
    }

    protected override void WizAwake()
    {
        base.WizAwake();
        wizAimStick = GameObject.Find("AimStick").GetComponent<WizAimStick>();
    }

    public virtual void WizRotate(Vector3 rot)
    {
        wizOB.transform.position = playerGM.transform.position;
        wizOB.transform.eulerAngles = new Vector3(0f, 0f, -Mathf.Atan2(rot.x, rot.y) * Mathf.Rad2Deg);
    }
}
