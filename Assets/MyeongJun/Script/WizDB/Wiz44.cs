using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz44 : AimWiz
{
    private void Awake()
    {
        wizGrade = 3;

        effectSpeed = 3f;
        destroyDistance = 15f;
        damage = 150;

        effectTime = 0;
        knockBackDistance = 5f;
        effectDamage = 0;
        slowRate = 0f;
        wizType = 4;

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
        wizOBCode.obKnockBackDistance = knockBackDistance;
        wizOBCode.slowRate = slowRate;
        wizOBCode.obType = wizType;

        wizOBCode.WizAffect = wizOBCode.WizGiveDamage;
        wizOBCode.WizAffect = wizOBCode.WizMakeKnockBack;
    }
}
