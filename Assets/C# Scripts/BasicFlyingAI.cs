using UnityEngine;
using System.Collections;

public class BasicFlyingAI : MonoBehaviour
{
    [SerializeField] private float chaseSpeed = 10.0f;
    [SerializeField] private float runAwaySpeed = 8.0f;
    Player _player;
    private Transform target;

    private float rotateSpeed = 3f;
    private float radius = 2f;

    private Vector2 _centre;
    private float _angle;

    [SerializeField] private float waitTime = 8.5f;
    private float timer = 0.0f;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _centre = transform.position;
    }

    void Update()
    {
        int actions = Random.Range(0, 2);
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            switch (actions)
            {
                case 0:
                    transform.position = Vector2.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);
                    break;
                case 1:
                    transform.Translate(Vector2.left * runAwaySpeed * Time.deltaTime);
                    break;
                default:
                    break;
            }
        }
        else
        {
            _centre += new Vector2(_player.currentSpeed, 0) * Time.deltaTime;

            _angle += rotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;
            transform.position = _centre + offset;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float angle = 180;
        transform.Rotate(0, angle, 0);
    }
}
