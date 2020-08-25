using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int monsterHP;
    protected float moveSpeed;

    protected bool harded;
    protected bool burning;
    protected bool slow;

    protected int hardedTime;
    protected int burningTime;
    public int slowTime;

    protected int burningDamage;
    protected float slowRate;

    protected Vector3 pushRot;
    protected float knockBackDistance;
    protected float pushedDistance;
    protected float pushedTime;

    protected void MonInit()
    {
        harded = false;
        burning = false;
        slow = false;

        hardedTime = 0;
        burningTime = 0;
        burningDamage = 30;
        slowTime = 0;
        pushedTime = 0f;
    }

    public virtual void GetDamage(int damage)
    {
        monsterHP -= damage;
        Debug.Log("Damage : " + damage+ " / Monster HP : " + monsterHP);
    }

    protected void MonsterDie()
    {
        if(monsterHP <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log("꾸엑");
        }
    }

    public virtual void MonsterHarded(int time)
    {
        hardedTime = time;
        if(!harded)
            StartCoroutine("MonsterUnHarding");
        harded = true;
    }

    public virtual void MonsterBurn(int time, int damage)
    {
        burningTime += time * 2;
        if (!burning)
            StartCoroutine("MonsterBurning");
        burning = true;
    }

    public virtual void MonsterSlow(int time, float rate)
    {
        slowTime = time;
        slowRate = rate;
        if (!slow)
        {
            moveSpeed *= slowRate;
            StartCoroutine("MonsterSlowed");
        }
        slow = true;
    }

    public virtual void MonsterPushed(float distance, Vector3 spot)
    {
        Debug.Log("밀라고 했어요~");
        moveSpeed = 0f;
        pushRot = (transform.position - spot).normalized;
        knockBackDistance += distance * 0.16f;
        Debug.Log(pushRot);
        Debug.Log(distance);
        StartCoroutine("MonsterPush");
    }

    public IEnumerator MonsterUnHarding()
    {
        moveSpeed = 0f;
        while (hardedTime > 0)
        {
            yield return new WaitForSeconds(1f);
            hardedTime--;
        }
        harded = false;
        moveSpeed = 0.5f;
    }

    public IEnumerator MonsterBurning()
    {
        while (burningTime > 0)
        {
            yield return new WaitForSeconds(0.5f);
            GetDamage(burningDamage);
            burningTime--;
        }
        burning = false;
    }

    public IEnumerator MonsterSlowed()
    {
        Debug.Log("Slow!");
        while (slowTime > 0)
        {
            yield return new WaitForSeconds(1f);
            slowTime--;
        }
        Debug.Log("Back!");
        moveSpeed = moveSpeed / slowRate;
        slow = false;
    }

    public IEnumerator MonsterPush()
    {
        while(pushedDistance < knockBackDistance)
        {
            transform.position += pushRot * 2 * knockBackDistance * Time.deltaTime;
            pushedDistance += knockBackDistance * 2 * Time.deltaTime;
            yield return new WaitForSeconds(0);
        }
        moveSpeed = 0.5f;
        knockBackDistance = 0;
        pushedDistance = 0;
    }
}
