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
    private GameObject player;
    private Text nbPlank;
    private Text nbIron;
    private Text nbMunition;
    private Text nbCoin;
    private Text winnerText;
    private Text tooFatText;
    private Text infoText;

    private RectTransform healthBar;
    private RectTransform energyBar;

    private float tooFatTextTimer = 0;
    private float littleHotTextTimer = 0;

    private void Update()
    {
        Show(player.GetComponent<Player>().GetInventory());
        Show(player);
        RestartText();
    }

    public void Show(Inventory inventory)
    {
        nbPlank.GetComponent<Text>().text = inventory.Contain("Plank").ToString();
        nbIron.GetComponent<Text>().text = inventory.Contain("Iron").ToString();
        nbMunition.GetComponent<Text>().text = inventory.GetNbMunition().ToString();
        nbCoin.GetComponent<Text>().text = inventory.GetNbCoin().ToString();
    }

    public void Show(GameObject player)
    {
        healthBar.sizeDelta = new Vector2((player.GetComponent<Player>().GetHealth() / 100f * 473.2f), 18.5f);
        energyBar.sizeDelta = new Vector2((player.GetComponent<Player>().GetEnergy() / 100f * 473.2f), 18.5f);
        if (player.GetComponent<Player>().GetHealth() <= 0)
        {
            winnerText.GetComponent<Text>().text = "You F*cked Up Fat Boy";
        }
        if (player.GetComponent<Player>().GetWin())
        {
            winnerText.GetComponent<Text>().text = "You Won... Now What?";
        }
    }

    public void RestartText()
    {
        if (Time.fixedTime > tooFatTextTimer + 0.1f)
        {
            tooFatText.GetComponent<Text>().text = "";
        }
        if (Time.fixedTime > littleHotTextTimer + 0.1f)
        {
            infoText.GetComponent<Text>().text = "";
        }
    }

    public void SetInfoText(string value)
    {
        infoText.GetComponent<Text>().text = value;
    }

    public void SetTooFatText(string value)
    {
        tooFatText.GetComponent<Text>().text = value;
    }

    public void SetTooFatTextTimer(float value)
    {
        tooFatTextTimer = value;
    }

    public void SetLittleHotTimer(float value)
    {
        littleHotTextTimer = value;
    }

    public string GetInfoText()
    {
        return infoText.GetComponent<Text>().text;
    }

}

