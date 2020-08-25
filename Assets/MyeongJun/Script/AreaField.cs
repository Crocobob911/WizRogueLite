using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaField : MonoBehaviour
{

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        AreaShow();
    }

    public void AreaShow()
    {
        transform.position = player.transform.position;
    }
}
