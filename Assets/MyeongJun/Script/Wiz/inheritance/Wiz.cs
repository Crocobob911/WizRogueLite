using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz : MonoBehaviour
{
    public float wizCastSpeed;
    public Sprite wizSprite;

    protected int wizId;
    protected int wizGrade;
    protected int wizType;
    protected string wizName;

    private void Start()
    {
        wizCastSpeed = 1f;
    }

    public virtual void WizActive() //wiz 게임 오브젝트에 위즈 정보 씌우기
    {

    }

    public virtual void WizMove() //위즈 이펙트의 운동
    {

    }

    public virtual void WizTypeEffect() //위즈 계열에 따른 능력
    {

    }

    public virtual void WizEffect() //위즈의 효과
    {

    }
}
