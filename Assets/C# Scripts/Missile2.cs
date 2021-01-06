using UnityEngine;
using System.Collections;

public class Missile2 : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject alienExplosionFX;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Blockade _blockade = col.GetComponent<Blockade>();
        if (_blockade != null)
        {
            Destroy(_blockade.gameObject);
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12) //trafienie wroga (layer 11) lub wrogiego pocisku (layer 12)
        {
            //+100 pkt za podstawowego wroga
            Player.score += 100;

            GameObject boom = Instantiate(alienExplosionFX, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
