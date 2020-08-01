using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPrac : Monster
{
    

    void Start()
    {
        Init();
    }

    private void Init()
    {
        monsterHP = 200;
    }


    void Update()
    {
        MonsterDie();
    }

}
