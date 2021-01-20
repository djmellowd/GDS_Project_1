using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            player.LooseLife();
        }

        if (collision.gameObject.layer == 12)
        {
            Destroy(collision.gameObject);
        }
    }

}
