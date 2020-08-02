using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz22 : AimWiz
{
    private WizProjectile wizOBCode;
    private void Awake()
    { 
        effectSpeed = 0.8f;
        destroyTime = 3f;
        damage = 250;
        wizGrade = 2;
        WizAwake();
    }

    protected override void WizAwake()
    {
        base.WizAwake();
        wizOB = transform.GetChild(0).gameObject;
        wizOBCode = wizOB.GetComponent<ProjectileNoneThrough>();
        wizOBCode.obEffectSpeed = effectSpeed;
        wizOBCode.obDestroyTime = destroyTime;
        wizOBCode.obDamage = damage;
    }
}
