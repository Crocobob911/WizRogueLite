using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Wiz : MonoBehaviour
{
    protected int wizId;
    protected int wizGrade;
    protected int wizType;

    protected float destroyTime;

    protected int damage;
    protected int effectTime;
    protected int effectDamage;
    protected float slowRate;
    protected float knockBackDistance;

    protected CastArea castArea;
    protected WizDirector wizDirector;
    protected GameObject playerGM;
    protected GameObject wizOB;
    protected WizController wizOBCode;

    protected virtual void WizAwake()
    {
        playerGM = GameObject.Find("Player");
        castArea = GameObject.Find("CastArea").GetComponent<CastArea>();
        wizDirector = GameObject.Find("WizDirector").GetComponent<WizDirector>();
    }

    protected IEnumerator WizInitializer()
    {
        yield return new WaitForSeconds(0);
        gameObject.SetActive(false);
    }

    protected virtual void WizMakeSlow(Collider2D coll, int time, float rate)
    {
        coll.gameObject.GetComponent<Monster>().MonsterSlow(time, rate);
    }
}
