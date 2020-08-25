using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizNoneRemainField : WizField
{

    private void Awake()
    {
        WizAwake();
    }

    private void OnEnable()
    {
        wizObOff = false;
        wizDirector.areaOnEdit.SetActive(false);
        transform.position = playerOb.transform.position;
        StartCoroutine("WizInitializer", obDestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            WizAffect(other, obEffectTime, obDamage, slowRate, obKnockBackDistance, obType);
        }
    }
}
