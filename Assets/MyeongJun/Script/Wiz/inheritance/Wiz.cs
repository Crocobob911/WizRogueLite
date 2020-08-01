using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Wiz : MonoBehaviour
{
    public float wizCastTime;
    public Sprite wizSprite;

    protected int wizId;
    protected int wizGrade;
    protected int wizType;
    protected string wizName;
    protected CastArea castArea;
    protected WizDirector wizDirector;
    

    private void Awake()
    {
        
    }



    protected virtual void WizAwake()
    {
        castArea = GameObject.Find("CastArea").GetComponent<CastArea>();
        wizDirector = GameObject.Find("WizDirector").GetComponent<WizDirector>();
    }
    public virtual void WizActive() //위즈 활성화
    {
        Debug.Log("Wiz Activated!");
    }

    public virtual void WizTypeEffect() //위즈 계열에 따른 능력
    {

    }

    public virtual void WizEffect() //위즈의 효과
    {

    }

    public void WizInitializer()
    {
        Destroy(this);
    }
}
