using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteShooting : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefabElite;
    private GameObject _rocket2;
    private AudioSource _sfx;

    bool _notShotYet;

    private void Start()
    {
        _sfx = GetComponent<AudioSource>();
        _notShotYet = true;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        GameObject hitObject = hit.transform.gameObject;
        if (hitObject.GetComponent<Player>())
        {
            if (_rocket2 == null && _notShotYet)
            {
                _rocket2 = Instantiate(rocketPrefabElite) as GameObject;
                _sfx.Play();
                _rocket2.transform.position = transform.TransformPoint(-Vector2.up * 1.0f);
                _rocket2.transform.rotation = transform.rotation;
                _notShotYet = false;
            }
        }
    }
}
