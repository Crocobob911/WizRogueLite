using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz13 : AimWiz
{
    private WizProjectile wizOBCode;
    private void Awake()
    {
        effectSpeed = 0.72f;
        destroyTime = 4.67f;
        damage = 250;
        wizGrade = 3;
        WizAwake();
    }

    protected override void WizAwake()
    {
        base.WizAwake();
        wizOB = transform.GetChild(0).gameObject;
        wizOBCode = wizOB.GetComponent<ProjectileThrough>();
        wizOBCode.obEffectSpeed = effectSpeed;
        wizOBCode.obDestroyTime = destroyTime;
        wizOBCode.obDamage = damage;
    }
}
