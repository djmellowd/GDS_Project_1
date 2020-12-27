using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Missile2 _missile2 = col.GetComponent<Missile2>();
        if (_missile2 != null)
        {
            Destroy(this.gameObject);
        }
    }
}
