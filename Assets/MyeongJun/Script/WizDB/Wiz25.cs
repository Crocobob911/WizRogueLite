using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz25 : AimWiz
{
    private void Awake()
    {
        wizGrade = 4;

        effectSpeed = 0f;
        destroyTime = 0.5f;
        damage = 400;

        effectTime = 0;
        effectDamage = 0;
        slowRate = 0f;
        wizType = 2;

        WizAwake();
    }

    protected override void WizAwake()
    {
        base.WizAwake();
        wizOB = transform.GetChild(0).gameObject;
        wizOBCode = wizOB.GetComponent<WizController>();
        wizOBCode.obEffectSpeed = effectSpeed;
        wizOBCode.obDestroyTime = destroyTime;
        wizOBCode.obDamage = damage;

        wizOBCode.obEffectTime = effectTime;
        wizOBCode.slowRate = slowRate;
        wizOBCode.obType = wizType;

        wizOBCode.WizAffect = wizOBCode.WizGiveDamage;
    }
}
