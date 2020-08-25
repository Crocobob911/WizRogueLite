using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizProjectile : WizController
{
    protected virtual void WizMove(float speed)
    {
        transform.Translate(Vector3.up * speed * 0.16f * Time.deltaTime);
    }
        /*if (!wizObOff)
        {
            
            wizObOff = false;
        }*/
    }

    /*protected virtual void WizTypeEffect(Collider2D other, int time, int damage, float rate, int type)
    {
        switch (type)
        {
            case 1:
                other.gameObject.GetComponent<Monster>().MonsterSlow(3, 0.8f);
                break;

            case 2:
                other.gameObject.GetComponent<Monster>().MonsterBurn(10, 5);
                break;

            case 3:
                other.gameObject.GetComponent<Monster>().MonsterHarded(2);
                break;

            default:
                break;
        }
    }*/
