using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBang : WizProjectile
{
    private void Awake()
    {
        WizAwake();
    }

    void OnEnable()
    {
        transform.localScale = new Vector3(0.096f, 0.096f, 0);
        wizObOff = false;
        StartCoroutine("WizInitializer", obDestroyTime);
    }

    void Update()
    {
        WizMove(obEffectSpeed);
    }

    protected override void WizMove(float speed)
    {
        base.WizMove(speed);
        transform.localScale += new Vector3(0.16f, 0.16f, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            WizAffect(other, obEffectTime, obDamage, slowRate, obKnockBackDistance, obType);
        }
    }
}
