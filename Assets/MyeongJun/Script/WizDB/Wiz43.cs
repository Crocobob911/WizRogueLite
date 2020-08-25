using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz43 : AimWiz
{ // Wind Flow

    private void Awake()
    {
        wizGrade = 1;

        effectSpeed = 0f;
        destroyTime = 1f;
        damage = 250;

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
