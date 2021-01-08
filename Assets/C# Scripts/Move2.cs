using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public Vector2 velocity;
    public float _angle;
    public float rotateSpeed = 3f;
    public float radius = 2f;
    public Vector2 _centre;
    public float duration;

    void execute(float stepSize, Transform enemy)
    {
        _angle += rotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;
        enemy.Translate(_centre + offset);
    }
}
