using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject[] tiles;

    public void ResetHoles()
    {
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = true;
            tile.GetComponent<Collider2D>().enabled = true;

            /*
            tile.GetComponentInChildren<SpriteRenderer>().enabled = false;
            tile.GetComponentInChildren<Collider2D>().enabled = false;
            tile.GetComponentInChildren<Hole>().enabled = false;
            */
        }
    }
}
