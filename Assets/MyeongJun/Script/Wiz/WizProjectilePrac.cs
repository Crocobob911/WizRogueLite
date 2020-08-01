using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizProjectilePrac : AimWiz
{   //조준 투사체 연습용

    public float effectSpeed;
    public float destroySpeed;
    public float castSpeed;
    public float damage;

    private void Awake()
    {
        WizAwake();
        wizCastTime = 2.5f;

    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public override void WizActive()
    {
        base.WizActive();
        
    }
}
