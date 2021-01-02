using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float height = 0.05f;

    Vector2 pos;
    Player _player;

    void Start()
    {
        pos = transform.position;
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.Rotate(0, 0, -1);

        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        transform.position = new Vector2(transform.position.x, newY);
    }
}
