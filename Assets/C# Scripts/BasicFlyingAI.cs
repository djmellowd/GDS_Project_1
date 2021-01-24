using UnityEngine;
using System.Collections;

public class BasicFlyingAI : MonoBehaviour
{
    [SerializeField] private float runAwaySpeed = 8.0f;
    Player _player;
    private Rigidbody2D target;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    [SerializeField] private float chaseSpeed = 4.0f;
    [SerializeField] private float chaseAngle = 15.0f;
    public GameObject explosionFX;

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

    private int _id;
    int id;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _centre = transform.position;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - transform.position).normalized * chaseSpeed;
        rb.velocity = new Vector2(moveDirection.x + 20, moveDirection.y);
        Random.seed = System.DateTime.Now.Millisecond;
        id = Random.Range(0, 2);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            FlyAway(id);
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
                _centre += new Vector2(_player.currentSpeed + forwardSpeed * Random.Range(1f, 1.2f), downSpeed) * Time.deltaTime;

                _angle += rotateSpeed * Time.deltaTime;
            }
            else if (timer > changeDirectionWaitTime && timer < changeDirectionWaitTime2)
            {
                _centre += new Vector2(_player.currentSpeed + backwardsSpeed * Random.Range(1f, 1.2f), upSpeed) * Time.deltaTime;

                _angle += rotateSpeed * Time.deltaTime;
            }
            else if (timer > changeDirectionWaitTime2)
            {
                _centre += new Vector2(_player.currentSpeed + 2.0f * Random.Range(1f, 1.2f), 0) * Time.deltaTime;

                _angle += rotateSpeed * Time.deltaTime;
            }

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;
            transform.position = _centre + offset;
        }
    }

    public void FlyAway(int id)
    {
        _id = id;
        if (_id == 1)
        {
            transform.Translate(Vector2.up * runAwaySpeed * Time.deltaTime);
        }
        else if (_id == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveDirection, chaseAngle * Time.deltaTime);
        }
    }
}
