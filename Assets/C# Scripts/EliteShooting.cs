using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteShooting : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefabElite;
    private GameObject _rocket2;
    private AudioSource _sfx;

    [SerializeField] private float flyingOutTime = 2.0f;
    private float timer = 0.0f;

    [SerializeField] private float runAwayWaitTime = 8.0f;

    bool _notShotYet;

    private void Start()
    {
        _sfx = GetComponent<AudioSource>();
        _notShotYet = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < flyingOutTime && timer < runAwayWaitTime)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<Player>())
            {
                if (_rocket2 == null && _notShotYet && !SceneController.isEliteMissileOnScene)
                {
                    _rocket2 = Instantiate(rocketPrefabElite) as GameObject;
                    _sfx.Play();
                    _rocket2.transform.position = transform.TransformPoint(-Vector2.up * 1.0f);
                    _rocket2.transform.rotation = transform.rotation;
                    _notShotYet = false;
                    SceneController.isEliteMissileOnScene = true;
                }
            }
        }
    }
}
