using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject hole;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            if (collision.gameObject.GetComponent<Rocket>().isElite)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;

                hole.GetComponent<SpriteRenderer>().enabled = true;
                hole.GetComponent<Collider2D>().enabled = true;
                hole.GetComponent<Hole>().enabled = true;
            }
        }
    }
}
