using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNoneThrough : WizProjectile
{
    private void Awake()
    {
        //WizAwake();
    }

    void OnEnable()
    {
        Invoke("WizInitializer", obDestroyTime);
    }

    void Update()
    {
        WizMove(obEffectSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            WizGiveDamage(other, obDamage);
        }
    }

    protected override void WizGiveDamage(Collider2D coll, int damage)
    {
        base.WizGiveDamage(coll, damage);
        WizInitializer();
    }
}
