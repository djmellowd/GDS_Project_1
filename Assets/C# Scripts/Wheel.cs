using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, -1);
    }
}
