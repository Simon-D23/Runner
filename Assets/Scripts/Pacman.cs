using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : Opponent
{
    private int ATT_TIMER = 3;
    private float currentAttTimer = 0;
    private int ANIM_ATT_TIMER = 1;
    private float currentAnimAttTimer = 0;
    private bool isAttacking = false;

    public override void init()
    {
        SetStartedSide("right");
        SetDamage(20);
        SetHealth(80);
    }

    public override void Attack()
    {
                      
    }
}
