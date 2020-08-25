using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz14 : AimWiz
{
    private void Awake()
    {
        wizGrade = 3;

        effectSpeed = 4.5f;
        destroyDistance = 14f;
        damage = 250;

        effectTime = 2;
        slowRate = 0.5f;
        wizType = 1;

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
        wizOBCode.WizAffect += wizOBCode.WizMakeSlow;
    }
}
