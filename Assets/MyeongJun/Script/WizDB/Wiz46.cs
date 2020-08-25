using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz46 : NoneAimWiz
{
    private void Awake()
    {
        wizGrade = 5;

        destroyTime = 0.5f;
        damage = 200;

        effectTime = 0;
        knockBackDistance = 20f;
        wizType = 4;

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
        wizOBCode.obKnockBackDistance = knockBackDistance;
        wizOBCode.obType = wizType;

        wizOBCode.WizAffect = wizOBCode.WizGiveDamage;
        wizOBCode.WizAffect = wizOBCode.WizMakeKnockBack;
    }
}
