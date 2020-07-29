using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WizAimStick : MonoBehaviour
{
    public GameObject aimStick;

    private void Awake()
    {
        aimStick = GameObject.Find("AimStick");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Aiming(BaseEventData _Data)
    {

    }
}
