using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

[SerializePrivateVariables]

public class Lava : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (Input.GetKey("c") && player.GetComponent<Player>().GetInventory().Contain("Iron") > 0)
            {
                player.GetComponent<Player>().GetInventory().AddMunition(33);
                player.GetComponent<Player>().GetInventory().Remove("Iron", 1);             
            }
            player.GetComponent<Player>().GetComponent<HUD>().SetInfoText("It's A Little Hot Here");
            player.GetComponent<Player>().GetComponent<HUD>().SetLittleHotTimer(Time.fixedTime);
        }
    }
}
