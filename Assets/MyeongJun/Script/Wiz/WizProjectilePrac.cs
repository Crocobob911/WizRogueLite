using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizProjectilePrac : AimWiz
{   //조준 투사체 연습용 발동

    public float effectSpeed;
    public float destroySpeed;
    public int damage;

    private void Awake()
    {
        WizAwake();
        effectSpeed = 3f;
        wizCastTime = 2.5f;
        destroySpeed = 2f;
        damage = 100;
    }

    private void OnEnable()
    {
        Invoke("WizInitializer", destroySpeed);
    }


    void Update()
    {
        transform.Translate(Vector3.up * effectSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            WizGiveDamage(other, damage);
        }
    }

    protected override void WizGiveDamage(Collider2D coll, int dam)
    {

        base.WizGiveDamage(coll, dam);
        WizInitializer();
    }

}

