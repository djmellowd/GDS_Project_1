﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}
