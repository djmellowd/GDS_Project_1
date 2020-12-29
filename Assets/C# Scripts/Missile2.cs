using UnityEngine;
using System.Collections;

public class Missile2 : MonoBehaviour
{
    public float speed = 5.0f;

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
}
