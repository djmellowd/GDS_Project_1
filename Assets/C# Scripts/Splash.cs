using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(gameObject);
        }
    }
}
