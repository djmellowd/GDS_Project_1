using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public Vector2 velocity;
    public float angularVelocity;
    public float duration;

    public void execute(float stepSize, Transform enemy)
    {
        enemy.Translate(enemy.forward * velocity * stepSize);
    }
}
