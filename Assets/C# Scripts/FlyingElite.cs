using UnityEngine;
using System.Collections;

public class FlyingElite : MonoBehaviour
{
    [SerializeField] private float runAwaySpeed = 8.0f;
    Player _player;

    private float _angle;
    private Vector2 direction;
    [SerializeField] private float forwardSpeed = 3.0f;
    [SerializeField] private float backwardsSpeed = -3.0f;

    [SerializeField] private float runAwayWaitTime = 4.0f;
    [SerializeField] private float changeDirectionWaitTime = 1.0f;
    [SerializeField] private float changeDirectionWaitTime2 = 2.0f;
    [SerializeField] private float changeDirectionWaitTime3 = 3.0f;
    private float timer = 0.0f;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        direction = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > runAwayWaitTime)
        {
            transform.Translate(Vector2.left * runAwaySpeed * Time.deltaTime);
        }
        else
        {
            if (timer < changeDirectionWaitTime)
            {
                direction += new Vector2(_player.currentSpeed + forwardSpeed, 0) * Time.deltaTime;
            }
            else if (timer > changeDirectionWaitTime && timer < changeDirectionWaitTime2)
            {
                direction += new Vector2(_player.currentSpeed + backwardsSpeed, 0) * Time.deltaTime;
            }
            else if (timer > changeDirectionWaitTime2 && timer < changeDirectionWaitTime3)
            {
                direction += new Vector2(_player.currentSpeed + forwardSpeed, 0) * Time.deltaTime;
            }
            else if (timer > changeDirectionWaitTime3)
            {
                direction += new Vector2(_player.currentSpeed + backwardsSpeed, 0) * Time.deltaTime;
            }
            transform.position = direction;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float angle = 180;
        transform.Rotate(0, angle, 0);
    }
}
