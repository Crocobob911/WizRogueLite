using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWiz : Wiz
{
    protected WizAimStick wizAimStick;
    protected GameObject wizOnEdit;

    private void Awake()
    {
        
    }

    protected virtual void SetAimStick()
    {
        wizAimStick.aimStick.SetActive(true);
    }

    protected override void WizAwake()
    {
        base.WizAwake();
        wizAimStick = GameObject.Find("AimStick").GetComponent<WizAimStick>();
    }

    public override void WizActive()
    {
        SetAimStick();
        wizOnEdit = wizDirector.wizOnEditGM;
    }

    public virtual void WizShoot(Vector3 rot)
    {

    }
}
