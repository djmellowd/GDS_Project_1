using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public float speed = 2.0f;
    public Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 10)
        {
            player.LooseLife();
        }
        else if (col.gameObject.layer == 12)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
