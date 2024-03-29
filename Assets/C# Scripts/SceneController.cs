﻿using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static bool isEliteMissileOnScene;
    public static bool isMissileOnScene;

    void Start()
    {
        //zerowanie wyniku na starcie
        Player.score = 0;
        isEliteMissileOnScene = false;
        isMissileOnScene = false;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x > Screen.width || screenPosition.x > Screen.height + 250)
        {
            GameObject[] allObjects1 = GameObject.FindGameObjectsWithTag("Enemy1");
            foreach (GameObject obj in allObjects1)
            {
                Destroy(obj);
            }

            GameObject[] allObjects2 = GameObject.FindGameObjectsWithTag("Enemy2");
            foreach (GameObject obj in allObjects2)
            {
                Destroy(obj);
            }

            GameObject[] allObjects3 = GameObject.FindGameObjectsWithTag("Enemy3");
            foreach (GameObject obj in allObjects3)
            {
                Destroy(obj);
            }

            GameObject[] allObjects4 = GameObject.FindGameObjectsWithTag("Enemy4");
            foreach (GameObject obj in allObjects4)
            {
                Destroy(obj);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
