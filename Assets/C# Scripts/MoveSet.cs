using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSet : MonoBehaviour
{
    public Vector2 spawnOffset;
    public Move[] moves;
    private int currentMove = 0;
    private float moveTime;

    public bool execute(float stepSize, Transform enemy)
    {
        moves[currentMove].execute(stepSize, enemy);
        moveTime += stepSize;
        if (moveTime >= moves[currentMove].duration)
        {
            currentMove += 1;
            moveTime = 0;
            if (currentMove >= moves.Length)
                return true;
        }
        return false;
    }
}
