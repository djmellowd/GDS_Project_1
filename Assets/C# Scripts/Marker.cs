using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NUnit.Framework;

public class Marker : MonoBehaviour
{
    public string currentStage;
    public bool checksForBonus;
    public int averageTime;
    public GameObject bonusScreen;
    HUDController hudController;
    Player player;
    int bonus;

    private void Start()
    {
        hudController = FindObjectOfType<HUDController>();
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hudController.stage = currentStage;
        player.checkpoint.position = transform.position;
        bonusScreen.GetComponent<BonusScreen>().titleText.text = "Time to reach point " + currentStage;

        if (checksForBonus)
        {
            bonusScreen.SetActive(true);
            bonusScreen.GetComponent<BonusScreen>().averageTimeText.text = averageTime.ToString();
            //TYMCZASOWY REKORD
            if (hudController.timer < averageTime)
            {
                bonusScreen.GetComponent<BonusScreen>().recordTimeText.text = ((int)hudController.timer).ToString();
            }
            else
            {
                bonusScreen.GetComponent<BonusScreen>().recordTimeText.text = averageTime.ToString();
            }

            //przyznanie bonusa
            if ((int)hudController.timer < averageTime)
            {
                bonus = 1000 + ((averageTime - (int)hudController.timer) * 10);
                bonusScreen.GetComponent<BonusScreen>().bonusText.text = bonus.ToString();
                Player.score += bonus;
            }

            Time.timeScale = 0f;
            checksForBonus = false;
        }
    }
}
