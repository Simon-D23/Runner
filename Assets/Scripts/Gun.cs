using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts
{
    class Gun : Item
    {
        private int munition = 0;
        private int damage = 0;
        private float firerate = 0.5f;
        private float firerateTimer = 0;

        public override void Use(Player player)
        {           
            if (Input.GetKey("k") && player.GetInventory().GetNbMunition() > 0)
            {
                if (Time.fixedTime - firerateTimer > firerate)
                {
                    player.GetInventory().DecreaseMunition(1);                
                    Bullet bullet = new Bullet();
                    bullet.Create(player);
                    BulletsRep.Add(bullet);
                    firerateTimer = Time.fixedTime;
                }
            }
        }


    }
}
