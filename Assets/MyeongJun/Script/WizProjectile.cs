using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizProjectile : MonoBehaviour
{
    protected GameObject playerGM;
    public float obEffectSpeed;
    public float obDestroyTime;
    public int obDamage;

    protected void WizAwake()
    {
        playerGM = GameObject.Find("Player");
    }



    protected virtual void WizMove(float speed)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    protected virtual void WizGiveDamage(Collider2D coll, int damage)
    {
        coll.gameObject.GetComponent<Monster>().GetDamage(damage);
    }

    protected virtual void WizInitializer()
    {
        gameObject.SetActive(false);
    }
}
