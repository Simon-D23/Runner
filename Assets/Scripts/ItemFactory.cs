using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class ItemFactory
{
    public static void Create(string name, float x, float y)
    {
        if (name.Equals("Iron"))
        {
            GameObject iron = new GameObject("Iron");
            iron.transform.position = new Vector3(x, y, -2);
            iron.transform.localScale += new Vector3(-0.5f, -0.5f, 0);
            iron.AddComponent<SpriteRenderer>();
            iron.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Iron");
            iron.AddComponent<BoxCollider2D>().isTrigger = true;
            iron.tag = "Item";
        }
    }
}

