using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz01 : AimWiz
{
    private void Awake()
    {
        wizGrade = 0;

        effectSpeed = 13f;
        destroyDistance = 10f;
        damage = 150;

        effectTime = 0;
        effectDamage = 0;
        slowRate = 0f;
        wizType = 0;

        WizAwake();
    }

    protected override void WizAwake()
    {
        base.WizAwake();
        destroyTime = destroyDistance / effectSpeed;
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