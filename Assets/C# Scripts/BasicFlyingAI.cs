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
    private int _id2;
    private int _id3;
    private int _id4;
    int id;
    int id2;
    int id3;
    int id4;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _centre = transform.position;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - transform.position).normalized * chaseSpeed;
        rb.velocity = new Vector2(moveDirection.x + 20, moveDirection.y);
        id = Random.Range(0, 2);
        id2 = Random.Range(0, 2);
        id3 = Random.Range(0, 2);
        id4 = Random.Range(0, 2);
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
                StepChange(id2);
            }
            else if (timer > changeDirectionWaitTime && timer < changeDirectionWaitTime2)
            {
                StepChange2(id3);
            }
            else if (timer > changeDirectionWaitTime2)
            {
                StepChange3(id4);
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

    public void StepChange(int id2)
    {
        _id2 = id2;
        if (_id2 == 1)
        {
            _centre += new Vector2(_player.currentSpeed + (forwardSpeed * Random.Range(0.9f, 1.2f)), downSpeed) * Time.deltaTime;

            _angle += rotateSpeed * Time.deltaTime;
        }
        else if (_id2 == 0)
        {
            _centre += new Vector2(_player.currentSpeed + (backwardsSpeed * Random.Range(0.9f, 1.2f)), downSpeed) * Time.deltaTime;

            _angle += rotateSpeed * Time.deltaTime;
        }
    }

    public void StepChange2(int id3)
    {
        _id3 = id3;
        if (_id3 == 1)
        {
            _centre += new Vector2(_player.currentSpeed + (backwardsSpeed * Random.Range(0.9f, 1.2f)), upSpeed) * Time.deltaTime;

            _angle += rotateSpeed * Time.deltaTime;
        }
        else if (_id3 == 0)
        {
            _centre += new Vector2(_player.currentSpeed + (forwardSpeed * Random.Range(0.9f, 1.2f)), upSpeed) * Time.deltaTime;

            _angle += rotateSpeed * Time.deltaTime;
        }
    }

    public void StepChange3(int id4)
    {
        _id4 = id4;
        if (_id4 == 1)
        {
            _centre += new Vector2(_player.currentSpeed + 2.0f, 0) * Time.deltaTime;

            _angle += rotateSpeed * Time.deltaTime;
        }
        else if (_id4 == 0)
        {
            _centre += new Vector2(_player.currentSpeed + 3.0f, 0) * Time.deltaTime;

            _angle += rotateSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
