using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    [SerializeField] public float angle = 10.0f;
    [SerializeField] public float speed = 10.0f;
    public GameObject explosionFX;
    private Player player;
    private Rigidbody2D target;
    private Vector2 moveDirection;
    private Rigidbody2D rb;


    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x + 20, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveDirection, angle * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 10)
        {
            player.LooseLife();
        }
        else if (col.gameObject.layer == 12)
        {
            GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.layer == 13)
        {
            GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
