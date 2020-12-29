using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
