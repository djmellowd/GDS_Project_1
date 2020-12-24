using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
}
