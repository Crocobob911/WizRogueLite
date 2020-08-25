using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirector : MonoBehaviour
{
    private GameObject player;
    private Vector3 cameraPosition;
    private float followSpeed;

    void Start()
    {
        player = GameObject.Find("Player");
        followSpeed = 0.08f;
    }

    void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x;
        cameraPosition.y = player.transform.position.y;
        cameraPosition.z = player.transform.position.z - 3f;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed + Time.deltaTime);
    }
}
