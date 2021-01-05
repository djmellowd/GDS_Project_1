using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12) //trafienie wroga (layer 11) lub wrogiego pocisku (layer 12)
        {
            //+100 pkt za podstawowego wroga
            Player.score += 100;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
