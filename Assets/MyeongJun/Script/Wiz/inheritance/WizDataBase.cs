using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizDataBase : MonoBehaviour
{
    public WizProjectilePrac WizPractice;

    private void Awake()
    {
        WizPractice = GameObject.Find("WizDB").GetComponent<WizProjectilePrac>();
        
    }

    void Update()
    {

    }
}
