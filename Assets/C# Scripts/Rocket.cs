using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public float speed = 3.0f;

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Player _player = col.GetComponent<Player>();
        if (_player != null)
        {
            Destroy(_player.gameObject);
        }
        Destroy(this.gameObject);
    }
}
