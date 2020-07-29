using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizDirector : MonoBehaviour
{
    private string lineNumbers;
    private GameObject[] wizGameObjects = new GameObject[3];

    private void Awake()
    {

    }

    private void Start()
    {
        lineNumbers = "9999999999";
    }

    public void WizDectector(int[] lines)
    {
        lineNumbers = Convert.ToString(lines[0]) + Convert.ToString(lines[1]) + Convert.ToString(lines[2]) + Convert.ToString(lines[3]) + Convert.ToString(lines[4]);

        switch (lineNumbers)
        {
            // 이제 여기서 올바른 위즈를 판단해주고,
            // 적당한 위치(wiz 1, 2, 3 중 하나)에 그 위즈를 배정해주는 역할을 할거야
            // 조준이냐 범위냐 따라 다르게 행동하는 것도 위즈 각자가 해야할 일이야
        }
    }
}
