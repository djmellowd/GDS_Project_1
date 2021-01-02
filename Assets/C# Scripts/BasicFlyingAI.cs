using UnityEngine;
using System.Collections;

public class BasicFlyingAI : MonoBehaviour
{
    public float speed = 0;
    Player _player;
    private Transform target;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        speed = _player.currentSpeed + 3.0f;
        transform.Translate(speed * Time.deltaTime, 0, 0);
        Invoke("Following", 10);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float angle = 180;
        transform.Rotate(0, angle, 0);
    }
    
    void Following()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
