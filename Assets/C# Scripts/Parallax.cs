using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    public float parallaxEffect;


    public bool resetAtCheckpoint = false;

    private float _length;
    private float _startPosition;
    float _resetPositionMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _resetPositionMultiplier = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //określamy z jaką prędkością ma poruszać się dany element tła
        float dist = (cam.transform.position.x * parallaxEffect);

        //poruszamy elementem tła
        transform.position = new Vector3(_startPosition + dist, transform.position.y, transform.position.z);

        if (resetAtCheckpoint)
        {
            _startPosition = (cam.transform.position.x-dist)*_resetPositionMultiplier;
            resetAtCheckpoint = false;
            _resetPositionMultiplier -= 0.25f;
        }
    }
}
