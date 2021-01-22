using UnityEngine;
using System.Collections;

public class BasicFlyingAI : MonoBehaviour
{
    [SerializeField] private float runAwaySpeed = 8.0f;
    Player _player;
    private Transform target;

    private float rotateSpeed = 3f;
    private float radius = 2f;

    private Vector2 _centre;
    private float _angle;

    [SerializeField] private float waitTime = 9.0f;
    [SerializeField] private float flyingOutTime = 2.0f;
    [SerializeField] private float flyingOutDistance = -3.0f;
    private float timer = 0.0f;

    [SerializeField] private float changeDirectionWaitTime = 3.0f;
    [SerializeField] private float changeDirectionWaitTime2 = 6.0f;

    [SerializeField] private float forwardSpeed = 3.0f;
    [SerializeField] private float backwardsSpeed = -3.0f;

    [SerializeField] private float upSpeed = 1.0f;
    [SerializeField] private float downSpeed = -1.0f;

    private Vector2 direction;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _centre = transform.position;
        direction = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            transform.Translate(Vector2.left * runAwaySpeed * Time.deltaTime);
        }
        else if (timer < flyingOutTime)
        {
            _centre += new Vector2(_player.currentSpeed, flyingOutDistance) * Time.deltaTime;

            _angle += rotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;
            transform.position = _centre + offset;
        }
        else
        {
            if (timer < changeDirectionWaitTime)
            {
                _centre += new Vector2(_player.currentSpeed + forwardSpeed, downSpeed) * Time.deltaTime;

                _angle += rotateSpeed * Time.deltaTime;
            }
            else if (timer > changeDirectionWaitTime && timer < changeDirectionWaitTime2)
            {
                _centre += new Vector2(_player.currentSpeed + backwardsSpeed, upSpeed) * Time.deltaTime;

                _angle += rotateSpeed * Time.deltaTime;
            }
            else if (timer > changeDirectionWaitTime2)
            {
                _centre += new Vector2(_player.currentSpeed + 2.0f, 0) * Time.deltaTime;

                _angle += rotateSpeed * Time.deltaTime;
            }

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
