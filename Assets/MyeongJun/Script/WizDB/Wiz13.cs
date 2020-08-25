using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz13 : NoneAimWiz
{
    private void Awake()
    {
        wizGrade = 2;

        destroyTime = 15f;
        damage = 0;

        effectTime = 2;
        slowRate = 0.5f;
        wizType = 1;

        WizAwake();
    }

    protected override void WizAwake()
    {
        base.WizAwake();
        wizOB = transform.GetChild(0).gameObject;
        wizOBCode = wizOB.GetComponent<WizController>();
        wizOBCode.obDestroyTime = destroyTime;
        wizOBCode.obDamage = damage;

        wizOBCode.obEffectTime = effectTime;
        wizOBCode.slowRate = slowRate;
        wizOBCode.obType = wizType;

        wizOBCode.WizAffect = wizOBCode.WizMakeSlow;
    }
}
