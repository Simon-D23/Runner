using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            ItemFactory.Create("Iron", collision.transform.position.x + 1, collision.transform.position.y - 0.2f);
            GunFactory.CreateGameObject("Rifle", collision.transform.position.x - 1, collision.transform.position.y - 0.2f);
            gameObject.SetActive(false);
        }
    }
}

