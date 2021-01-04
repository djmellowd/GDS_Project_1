using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Player.score += 50;
        }
    }
}
