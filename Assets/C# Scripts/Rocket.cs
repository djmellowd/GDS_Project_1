using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Rocket : MonoBehaviour
{
    [SerializeField] public float angle = 10.0f;
    [SerializeField] public float speed = 4.0f;
    public GameObject explosionFX;
    public bool isElite;

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
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveDirection, angle * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 10)
        {
            player.LooseLife();
            Destroy(gameObject);
        }
        else if (col.gameObject.layer == 12)
        {
            GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.gameObject.layer == 13)
        {
            GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(isElite)
        {
            SceneController.isEliteMissileOnScene = false;
        }
        else
        {
            SceneController.isMissileOnScene = false;
        }
    }
}
