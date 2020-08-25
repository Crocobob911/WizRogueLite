using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WizRemainField : WizField
{
    protected float nowTime;

    private void Awake()
    {
        WizAwake();
    }

    private void Start()
    {
        RemainFieldInit();
    }

    private void OnEnable()
    {
        wizObOff = false;
        wizDirector.areaOnEdit.SetActive(false);
        transform.position = playerOb.transform.position;
        StartCoroutine("WizInitializer", obDestroyTime);
    }

    private void RemainFieldInit()
    {
        nowTime = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            WizAffect(other, obEffectTime, obDamage, slowRate, obKnockBackDistance, obType);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            other.gameObject.GetComponent<Monster>().slowTime = 2;
        }
    }
}
