using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Player player;
    public GameObject explosionFX;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            player.LooseLife();
        }
        else if (collision.gameObject.layer == 9)
        {
            Player.score += 100;
            GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
