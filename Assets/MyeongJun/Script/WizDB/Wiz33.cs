using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz33 : NoneAimWiz
{
    private void Awake()
    {
        wizGrade = 3;

        destroyTime = 1f;
        damage = 250;

        effectTime = 2;
        slowRate = 0f;
        wizType = 3;

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

        wizOBCode.WizAffect = wizOBCode.WizGiveDamage;
        wizOBCode.WizAffect += wizOBCode.WizMakeHarded;
    }
}
