using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int monsterHP;
    protected float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
