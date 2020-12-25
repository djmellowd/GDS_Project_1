using UnityEngine;
using System.Collections;

public class BasicFlyingAI : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    private GameObject _rocket;

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.distance < obstacleRange)
            {
                float angle = 0;
                transform.Rotate(0, angle, 0);
            }
    }
}
