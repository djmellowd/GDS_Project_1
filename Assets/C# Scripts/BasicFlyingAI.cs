using UnityEngine;
using System.Collections;

public class BasicFlyingAI : MonoBehaviour
{
    public float speed = 3.0f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float angle = 180;
        transform.Rotate(0, angle, 0);
    }
}
