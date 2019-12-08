using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[SerializePrivateVariables]

public class HUD : MonoBehaviour
{
    private Player player;
    private Text nbPlank;
    private Text nbIron;
    private Text nbMunition;
    private Text nbCoin;
    private Text gameOverText;

    private RectTransform healthBar;
    private RectTransform energyBar;

    private void Update()
    {
        show(player.GetInventory());
        show(player);
    }

    public void show(Inventory inventory)
    {
        nbPlank.GetComponent<Text>().text = inventory.Contain("Plank").ToString();
        nbIron.GetComponent<Text>().text = inventory.Contain("Iron").ToString();
        nbMunition.GetComponent<Text>().text = inventory.GetNbMunition().ToString();
        nbCoin.GetComponent<Text>().text = inventory.GetNbCoin().ToString();
    }

    public void show(Player player)
    {
        healthBar.sizeDelta = new Vector2((player.GetHealth() / 100f * 473.2f), 18.5f);
        energyBar.sizeDelta = new Vector2((player.GetEnergy() / 100f * 473.2f), 18.5f);
        if (player.GetHealth() <= 0)
        {
            gameOverText.GetComponent<Text>().text = "You F*cked Up Fat Boy";
        }
    }

   

}

