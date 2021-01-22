using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointStart : MonoBehaviour
{
    [SerializeField] private float runAwaySpeed = 8.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            GameObject[] allObjects1 = GameObject.FindGameObjectsWithTag("Enemy1");
            foreach (GameObject obj in allObjects1)
            {
                transform.Translate(Vector2.left * runAwaySpeed * Time.deltaTime);
            }

            GameObject[] allObjects2 = GameObject.FindGameObjectsWithTag("Enemy2");
            foreach (GameObject obj in allObjects2)
            {
                transform.Translate(Vector2.left * runAwaySpeed * Time.deltaTime);
            }

            GameObject[] allObjects3 = GameObject.FindGameObjectsWithTag("Enemy3");
            foreach (GameObject obj in allObjects3)
            {
                transform.Translate(Vector2.left * runAwaySpeed * Time.deltaTime);
            }

            GameObject[] allObjects4 = GameObject.FindGameObjectsWithTag("Enemy4");
            foreach (GameObject obj in allObjects4)
            {
                transform.Translate(Vector2.left * runAwaySpeed * Time.deltaTime);
            }
        }
    }
}
