using UnityEngine;
using System.Collections;

public class BasicShootingAI : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    private GameObject _rocket;
    private AudioSource _sfx;

    [SerializeField] private float flyingOutTime = 1.0f;
    private float timer = 0.0f;

    [SerializeField] private float waitTime = 9.0f;

    private void Start()
    {
        _sfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > flyingOutTime && timer < waitTime)
        {
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            //GameObject hitObject = hit.transform.gameObject;
            //if (hitObject.GetComponent<Player>())
            //{
                if (_rocket == null && !SceneController.isMissileOnScene)
                {
                    _rocket = Instantiate(rocketPrefab) as GameObject;
                    _sfx.Play();
                    _rocket.transform.position = transform.TransformPoint(-Vector2.up * 1.0f);
                    _rocket.transform.rotation = transform.rotation;
                    SceneController.isMissileOnScene = true;
                }
            //}
        }
    }
}