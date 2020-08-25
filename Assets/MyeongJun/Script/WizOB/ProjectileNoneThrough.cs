using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNoneThrough : WizProjectile
{
    private void Awake()
    {
        WizAwake();
    }

    void OnEnable()
    {
        wizObOff = false;
        StartCoroutine("WizInitializer", obDestroyTime);
    }

    void Update()
    {
        WizMove(obEffectSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            WizAffect(other, obEffectTime, obDamage, slowRate, obKnockBackDistance, obType);
        }
    }

    public override void WizGiveDamage(Collider2D other, int time, int damage, float rate, float distance, int type)
    {
        base.WizGiveDamage(other, time, damage,rate, distance, type);
        StartCoroutine("WizInitializer", 0);
    }
}
