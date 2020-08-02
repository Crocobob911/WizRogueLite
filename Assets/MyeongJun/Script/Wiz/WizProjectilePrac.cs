using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizProjectilePrac : AimWiz
{   //물 3성 웨이브

    private void Awake()
    {
        wizId = 13;

        WizAwake();
        effectSpeed = 3f;
        destroyTime = 2f;
        damage = 100;
    }

    private void OnEnable()
    {
        Invoke("WizInitializer", destroyTime);
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
}

