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

    private void Start()
    {
        hudController = FindObjectOfType<HUDController>();
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hudController.stage = currentStage;
        player.checkpoint.position = transform.position;

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

            Time.timeScale = 0f;
            checksForBonus = false;
        }
    }
}
