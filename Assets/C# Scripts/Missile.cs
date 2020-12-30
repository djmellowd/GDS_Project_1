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
        if (collision.gameObject.layer == 11)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
