using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int playerHp;
    public float playerSpeed;

    private MovingJoystick joyStick;


    void Start()
    {
        Init();
    }

    private void Init()
    {    
        joyStick = GameObject.Find("MovingJoyStickArea").GetComponent<MovingJoystick>();
        playerHp = 1;
        playerSpeed = 10f;
    }


    void Update()
    {
        if(joyStick.isMoving == true) 
            PlayerMove();

    }

    private void PlayerMove()
    {
        transform.Translate(Vector3.right * joyStick.joyMov.x * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * joyStick.joyMov.y * playerSpeed * Time.deltaTime);
    }
}
