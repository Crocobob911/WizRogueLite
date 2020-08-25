using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz22 : AimWiz
{
    private void Awake()
    { 
        wizGrade = 2;

        effectSpeed = 6f;
        destroyDistance = 15f;
        damage = 250;

        effectTime = 2;
        effectDamage = 50;
        slowRate = 0f;
        wizType = 2;

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
        wizOBCode.WizAffect += wizOBCode.WizMakeBurn;
    }
}
