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
        InvokeRepeating("rotAngleChange", 0f, 2f);
    }

    private void Init()
    {
        MonInit();
        monsterHP = 10000;
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

    private void rotAngleChange()
    {
        rot *= -1;
    }
}
