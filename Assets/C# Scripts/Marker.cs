﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public string currentStage;
    public bool checksForBonus;
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
            Time.timeScale = 0f;
            checksForBonus = false;
        }
    }
}
