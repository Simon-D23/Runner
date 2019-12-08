using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts;



namespace Assets.Scripts
{
    class BulletsRep : MonoBehaviour
    {
        private static List<Bullet> bullets = new List<Bullet>();

        public static void Add(Bullet bullet)
        {
            bullets.Add(bullet);
        }

        public static void ToUpdate()
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.ToUpdate();
                if (bullet.IsDestroyed())
                {
                    bullets.Remove(bullet);
                }
            }
        }

        public static void Remove(Bullet bullet)
        {
            Destroy(bullet);
            bullets.Remove(bullet);           
        }

    }
}
