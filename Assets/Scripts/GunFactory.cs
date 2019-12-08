using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts;

class GunFactory
{

    public static Gun Create(string name)
    {
        if (name.Equals("rifle"))
        {
            return new Gun();
        }
        return null;
    }

    public static void CreateGameObject(string name, float x, float y)
    {
        if (name.Equals("Rifle"))
        {
            GameObject rifle = new GameObject("Rifle");
            rifle.transform.position = new Vector3(x, y, -2);
            rifle.transform.localScale += new Vector3(0.8f, 0.8f, 0);
            rifle.AddComponent<SpriteRenderer>();
            rifle.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("guns")[5];
            rifle.AddComponent<BoxCollider2D>().isTrigger = true;
            rifle.tag = "Gun";
        }
    }

}

