using UnityEngine;
using System.Collections;

public class BasicFlyingShootingAI : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    private GameObject _rocket;

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<Player>())
            {
                if (_rocket == null)
                {
                    _rocket = Instantiate(rocketPrefab) as GameObject;
                    _rocket.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _rocket.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
