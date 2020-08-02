using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPrac : Monster
{
    private float rot;

    void Start()
    {
        Init();
        rot = 1;
        InvokeRepeating("RotationChange", 0f, 1f);
    }

    private void Init()
    {
        monsterHP = 1000;
        moveSpeed = 0.5f;
    }


    void Update()
    {
        MonsterDie();
        MonsterPatrol();
    }

    private void MonsterPatrol()
    {
        transform.Translate(new Vector3(rot, 0, 0) * Time.deltaTime * moveSpeed);
    }

    private void RotationChange()
    {
        rot *= -1;
    }

}
