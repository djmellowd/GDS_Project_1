using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour
{
    PlayerCollider m_playerCollider;
    Player _player;

    void Start()
    {
        m_playerCollider = GetComponent<PlayerCollider>();
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.Rotate(0, 0, -1);

        if (m_playerCollider.IsOnGround == false)
        {
            transform.position = new Vector2(_player.transform.position.x, _player.transform.position.y - 0.5f);
        }
    }
}
