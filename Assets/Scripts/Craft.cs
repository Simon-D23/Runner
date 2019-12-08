using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;


class Craft
{

    public static void Create(Player player, string name)
    {
        if (name.Equals("Ladder"))
        {
            Ladder(player);
        }
    }

    public static void Ladder(Player player)
    {
        /*if (Input.GetKey("c") && player.GetInventory().Contain("Plank") > 1 && Time.fixedTime - player.GetCurrentActionTimer() > Player.ACTION_TIMER)
        {
            GameObject ladder = new GameObject("Ladder");
            ladder.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.3f, -2);
            ladder.transform.localScale += new Vector3(1.73f, 1.73f, 0);
            ladder.AddComponent<SpriteRenderer>();
            ladder.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("TerrainTileset")[24];
            ladder.AddComponent<BoxCollider2D>().isTrigger = true;
            ladder.tag = "Ladder";
            ladder.name = "Ladder";
            player.SetCurrentActionTimer(Time.fixedTime);
            player.GetInventory().Remove("Plank", 2);
        }*/
    }
}

