using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    private float _length;
    private float _startPosition;

    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //określamy z jaką prędkością ma poruszać się dany element tła
        float dist = (cam.transform.position.x * parallaxEffect);

        //poruszamy elementem tła
        transform.position = new Vector3(_startPosition + dist, transform.position.y, transform.position.z);
    }
}
