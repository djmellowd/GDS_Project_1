using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject alienExplosionFX;


    Player _player;
    float xSpeed;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        xSpeed = _player.currentSpeed;
    }

    void Update()
    {
        transform.Translate((xSpeed * Time.deltaTime)/2, speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12) //trafienie wroga (layer 11) lub wrogiego pocisku (layer 12)
        {
            //+100 pkt za podstawowego wroga
            Player.score += 100;
            GameObject boom = Instantiate(alienExplosionFX, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1f);
        }
        else if (collision.gameObject.layer == 17)
        {
            //+200 pkt za tri-orba
            Player.score += 200;
            GameObject boom = Instantiate(alienExplosionFX, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
