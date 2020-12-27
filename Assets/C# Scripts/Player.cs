﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 1500.0f;
    public float jumpForce = 18.0f;

    private Rigidbody2D _body;
    private BoxCollider2D _box;

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject missile2Prefab;
    private GameObject _missile;
    private GameObject _missile2;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _missile = Instantiate(missilePrefab, transform.position + transform.up * 2.0f, transform.rotation) as GameObject;
            _missile2 = Instantiate(missile2Prefab, transform.position + transform.right * 2.0f, transform.rotation) as GameObject;
        }
    }
}
