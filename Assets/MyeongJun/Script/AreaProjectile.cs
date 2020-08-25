using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaProjectile : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void AreaRotate(Vector3 rot)
    {
        transform.position = player.transform.position;
        transform.eulerAngles = new Vector3(0f, 0f, -Mathf.Atan2(rot.x, rot.y) * Mathf.Rad2Deg);
    }
}
