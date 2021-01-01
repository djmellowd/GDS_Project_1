using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;

    Camera _camera;
    float ViewPositionX, ViewPositionY, ViewWidth, ViewHeight;
    Player _player;

    private Vector3 _velocity = Vector3.zero;

    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);

        if (_player.currentSpeed == _player.speed2)
        {
            var zoom = 8;
            Camera.main.orthographicSize = zoom;
        }
        else if (_player.currentSpeed == _player.speed3)
        {
            var zoom = 9;
            Camera.main.orthographicSize = zoom;
        }
        else if (_player.currentSpeed == _player.speed4)
        {
            var zoom = 10;
            Camera.main.orthographicSize = zoom;
        }
        else if (_player.currentSpeed == _player.speed5)
        {
            var zoom = 11;
            Camera.main.orthographicSize = zoom;
        }
        else if (_player.currentSpeed == _player.speed1)
        {
            var zoom = 7;
            Camera.main.orthographicSize = zoom;
        }
    }
}
