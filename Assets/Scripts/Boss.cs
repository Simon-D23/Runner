using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts;



public class Boss : Opponent
{
    private int ATT_TIMER = 3;
    private float currentAttTimer = 0;
    private int ANIM_ATT_TIMER = 1;
    private float currentAnimAttTimer = 0;
    private bool isAttacking = false;
    
    public override void init()
    {
        SetStartedSide("right");
        SetDamage(35);
        SetHealth(150);
    }

    public override void Attack()
    {
        SetSpeed(-4);
        if (Time.fixedTime - currentAttTimer > ATT_TIMER)
        {
            isAttacking = true;
            currentAnimAttTimer = Time.fixedTime;
            currentAttTimer = Time.fixedTime + ANIM_ATT_TIMER;
        }
        if (Time.fixedTime - currentAnimAttTimer < ANIM_ATT_TIMER && isAttacking)
        {      
            gameObject.GetComponent<Animator>().Play("bossAtt_0");
            float attSpeed = (GetSide().Equals("right")) ? -16f : 16f;
            GetRigidBody().velocity = new Vector2(attSpeed, 0);           
        }
        if (Time.fixedTime - currentAnimAttTimer > ANIM_ATT_TIMER)
        {
            isAttacking = false;            
            gameObject.GetComponent<Animator>().Play("boss");
        }
       
    }

}

