using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Wiz : MonoBehaviour
{
    public float wizCastTime;

    protected int wizId;
    protected int wizGrade;
    protected int wizType;
    protected string wizName;
    protected CastArea castArea;
    protected WizDirector wizDirector;
    protected GameObject playerGM;
    

    private void Awake()
    {
        
    }



    protected virtual void WizAwake()
    {
        playerGM = GameObject.Find("Player");
        castArea = GameObject.Find("CastArea").GetComponent<CastArea>();
        wizDirector = GameObject.Find("WizDirector").GetComponent<WizDirector>();
    }

    protected virtual void WizGiveDamage(Collider2D coll, int damage)
    { 
            coll.gameObject.GetComponent<Monster>().GetDamage(damage);
    }
    /*

    public virtual void WizTypeEffect() //위즈 계열에 따른 능력
    {

    }

    public virtual void WizEffect() //위즈의 효과
    {

    }*/

    public void WizInitializer()
    {
        gameObject.SetActive(false);
    }
}
