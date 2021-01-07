using UnityEngine;
using System.Collections;

public class BasicFlyingAI : MonoBehaviour
{
    public float speed;
    Player _player;
    private Transform target;

    private float rotateSpeed = 3f;
    private float radius = 2f;

    private Vector2 _centre;
    private float _angle;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _centre = transform.position;
    }

    void Update()
    {
        speed = _player.currentSpeed;

        _angle += rotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;
        transform.position = _centre + offset;

        Invoke("Following", 12);
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
