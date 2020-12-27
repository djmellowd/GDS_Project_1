using UnityEngine;
using System.Collections;

public class Blockade : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Player _player = col.GetComponent<Player>();
        if (_player != null)
        {
            Destroy(_player.gameObject);
        }
    }
}
