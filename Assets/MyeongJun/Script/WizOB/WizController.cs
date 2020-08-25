using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizController : MonoBehaviour
{
    public delegate void WizAffection(Collider2D other, int time, int damage, float rate, float distance, int type);
    public WizAffection WizAffect;

    protected GameObject playerOb;
    public float obEffectSpeed;
    public float obDestroyTime;
    public int obDamage;

    public int obEffectTime;
    public float slowRate;
    public float obKnockBackDistance;
    public int obType;

    protected bool wizObOff;

    protected virtual void WizAwake()
    {
        playerOb = GameObject.Find("Player");
    }

    public virtual void WizGiveDamage(Collider2D other, int time, int damage, float rate, float distance, int type)
    {
        other.gameObject.GetComponent<Monster>().GetDamage(damage);
    }

    public virtual void WizMakeSlow(Collider2D other, int time, int damage, float rate, float distance, int type)
    {
        other.gameObject.GetComponent<Monster>().MonsterSlow(time, rate);
    }

    public virtual void WizMakeBurn(Collider2D other, int time, int damage, float rate, float distance, int type)
    {
        other.gameObject.GetComponent<Monster>().MonsterBurn(time, damage);
    }

    public virtual void WizMakeHarded(Collider2D other, int time, int damage, float rate, float distance, int type)
    {
        other.gameObject.GetComponent<Monster>().MonsterHarded(time);
    }

    public virtual void WizMakeKnockBack(Collider2D other, int time, int damage, float rate, float distance, int type)
    {
        other.gameObject.GetComponent<Monster>().MonsterPushed(distance, playerOb.transform.position);
    }

    protected IEnumerator WizInitializer(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
