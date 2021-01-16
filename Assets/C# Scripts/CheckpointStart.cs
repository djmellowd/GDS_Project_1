using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
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
        }
    }
}
