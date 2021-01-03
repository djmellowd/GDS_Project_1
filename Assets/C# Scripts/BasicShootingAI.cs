using UnityEngine;
using System.Collections;

public class BasicShootingAI : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    private GameObject _rocket;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        GameObject hitObject = hit.transform.gameObject;
        if (hitObject.GetComponent<Player>())
        {
            if (_rocket == null)
            {
                _rocket = Instantiate(rocketPrefab) as GameObject;
                _rocket.transform.position = transform.TransformPoint(-Vector2.up * 1.0f);
                _rocket.transform.rotation = transform.rotation;
            }
        }
    }
}