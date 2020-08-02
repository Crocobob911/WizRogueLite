using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrough : WizProjectile
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
}
