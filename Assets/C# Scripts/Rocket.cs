using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public float speed = 10.0f;
    public Player player;
    private Transform target;

    void Start()
    {
        player = FindObjectOfType<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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
        else if (col.gameObject.layer == 13)
        {
            Destroy(gameObject);
        }
    }
}
