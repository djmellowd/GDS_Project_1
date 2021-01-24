using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject explosionFX;

    Player _player;


    private void Start()
    {
        _player = FindObjectOfType<Player>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            _player.LooseLife();
        }
        else if (collision.gameObject.layer == 9)
        {
            Player.score += 100;
            GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 11)
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 12)
        {
            Destroy(collision.gameObject);
        }
    }
}
