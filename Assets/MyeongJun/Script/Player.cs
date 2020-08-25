using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float playerHp;
    public float playerMp;
    public float playerHpSpeed;
    public float playerMpSpeed;
    public float playerMoveSpeed;
    public float playerCastSpeed;

    private Vector3 rotation;
    private float rotAngle;
    private MovingJoystick joyStick;
    private Animator anim;
    private float animSpeed;

    private void Awake()
    {
        joyStick = GameObject.Find("MovingJoyStickArea").GetComponent<MovingJoystick>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Start()
    {
        Init();
    }

    private void Init()
    {    
        playerHp = 10f;
        playerMp = 10f;
        playerHpSpeed = 1f;
        playerMpSpeed = 1f;
        playerMoveSpeed = 1f;
        playerCastSpeed = 1f;
        rotation = new Vector3(0, -1, 0);
    }


    void Update()
    {
        PlayerMove();
            

        
    }


    private void PlayerMove() 
    {
        if (joyStick.isMoving == true)
        {
            transform.Translate(Vector3.right * joyStick.joyMov.x * playerMoveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * joyStick.joyMov.y * playerMoveSpeed * Time.deltaTime);
            rotation = joyStick.joyMov;
            rotAngle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            animSpeed = Vector3.Magnitude(joyStick.joyMov) / joyStick.jSRadius;
            anim.SetBool("isMoving", true);

            if (rotAngle >= -135 && rotAngle <= -45)
                anim.SetInteger("direction", 0); //front 앞모습
            else if (rotAngle > 135 || rotAngle < -135)
                anim.SetInteger("direction", 1); //left
            else if (rotAngle > -45 && rotAngle < 45)
                anim.SetInteger("direction", 2); //right
            else
                anim.SetInteger("direction", 3); //back 뒷모습
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        
    }

    public void wizRotateAnim(Vector3 rotate)
    {
        rotation = rotate;
        rotAngle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        anim.SetBool("isShooting", true);
        if (rotAngle >= -135 && rotAngle <= -45)
            anim.SetInteger("direction", 0); //front 앞모습
        else if (rotAngle > 135 || rotAngle < -135)
            anim.SetInteger("direction", 1); //left
        else if (rotAngle > -45 && rotAngle < 45)
            anim.SetInteger("direction", 2); //right
        else
            anim.SetInteger("direction", 3); //back 뒷모습

        Invoke("WizShootDone", 0.02f);
    }

    public void Blink()
    {
        transform.Translate(Vector3.right * rotation.x * 0.48f);
        transform.Translate(Vector3.up * rotation.y * 0.48f);
    }

    private void WizShootDone()
    {
        anim.SetBool("isShooting", false);
    }
}

