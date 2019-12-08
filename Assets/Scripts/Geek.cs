using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geek : Opponent
{

    private int ATT_TIMER = 3;
    private float currentAttTimer = 0;
    private int ANIM_ATT_TIMER = 1;
    private float currentAnimAttTimer = 0;
    private bool isAttacking = false;

    public override void init()
    {
        SetStartedSide("left");
        SetDamage(20);
        SetHealth(80);
    }

    public override void Attack()
    {
        SetSpeed(-2);
        if (Time.fixedTime - currentAttTimer > ATT_TIMER)
        {
            isAttacking = true;
            currentAnimAttTimer = Time.fixedTime;
            currentAttTimer = Time.fixedTime + ANIM_ATT_TIMER;
        }
        if (Time.fixedTime - currentAnimAttTimer < ANIM_ATT_TIMER && isAttacking)
        {
            gameObject.GetComponent<Animator>().Play("geekAttack");
            float attSpeed = (GetSide().Equals("right")) ? -7f : 7f;
            GetRigidBody().velocity = new Vector2(attSpeed, 0);
        }
        if (Time.fixedTime - currentAnimAttTimer > ANIM_ATT_TIMER)
        {
            isAttacking = false;
            gameObject.GetComponent<Animator>().Play("geekBoy");
        }

    }
}
