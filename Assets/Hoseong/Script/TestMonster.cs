using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : MonoBehaviour
{
    private PlayerTemp player;
    private Animator animator;

    private float hp_Max = 10;
    private float hp;

    private float spd = 1f;

    private Vector2? patrolSpot = null;
    private float patrolRange_Max = 10f;
    private float patrolRange_Min = -10f;

    private float detectRange = 3f;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        hp = hp_Max;

        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerTemp>();        //초기화 시점에서 플레이어를 갖고 있음

        LinkedSMB<TestMonster>.Initialise(animator, this);
    }

    public bool FindTarget()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= detectRange)
            return true;

        return false;
    }

    public bool MoveToTarget()
    {
        if (Vector2.Distance(player.transform.position, transform.position) >= detectRange)
            return false;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);

        return true;
    }

    public void StartPatrol()
    {
        if (patrolSpot == null)
        {
            patrolSpot = transform.position;
            patrolSpot += new Vector2(Random.Range(patrolRange_Min, patrolRange_Max), Random.Range(patrolRange_Min, patrolRange_Max));
            Debug.Log(patrolSpot);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)patrolSpot, spd * Time.deltaTime);

            if (Vector2.Distance(transform.position, (Vector2)patrolSpot) < 0.2f)
                patrolSpot = null;
        }
    }

    public void StopPatrol()
    {
        patrolSpot = null;
    }
}
