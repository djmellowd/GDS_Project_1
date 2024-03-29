﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusScreen : MonoBehaviour
{
    public TextMeshProUGUI playerTimeText;
    public TextMeshProUGUI averageTimeText;
    public TextMeshProUGUI recordTimeText;
    public TextMeshProUGUI bonusText;
    public TextMeshProUGUI titleText;

    public GameObject polygonMountains;
    public GameObject frontMountains;

    public Sprite mountains;
    public Sprite city;

    HUDController hudController;

    bool _isCityLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        hudController = FindObjectOfType<HUDController>();

        playerTimeText.text = ((int)hudController.timer).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _isCityLevel = !_isCityLevel;
            Time.timeScale = 1f;
            hudController.timer = 0f;
            gameObject.SetActive(false);

            frontMountains.GetComponent<Parallax>().resetAtCheckpoint = true;
            polygonMountains.GetComponent<Parallax>().resetAtCheckpoint = true;


            if (_isCityLevel)
            {
                frontMountains.GetComponent<SpriteRenderer>().sprite = city;
            } 
            else if (!_isCityLevel)
            {
                frontMountains.GetComponent<SpriteRenderer>().sprite = mountains;
            }
        }
    }
}
