﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //score i highscore. zmienne statyczne po to, zeby był do nich dostęp w innych scenach
    public static int score;
    public static int highscore;

    //liczba żyć gracza
    public int lives = 3;
    //ostatni zdobyty checkpoint
    public Transform checkpoint;

    [SerializeField] public float speed2 = 6;
    [SerializeField] public float speed3 = 9;
    [SerializeField] public float speed4 = 12;
    [SerializeField] public float speed5 = 15;
    [SerializeField] public float speed1 = 3;
    public float currentSpeed;
    
    public float jumpForce = 0.0001f;

    //efekt wybuchu
    public GameObject explosionFX;

    //animatory kół
    public Animator wheel1Anim;
    public Animator wheel2Anim;
    public Animator wheel3Anim;

    private Rigidbody2D _body;
    public PolygonCollider2D _box;

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject missile2Prefab;
    private GameObject _missile;
    private GameObject _missile2;
    private Camera cam;

    private bool hasPressedAccel;
    private bool hasPressedDeAccel;
    private float pressedAccelTime;
    private float pressedDeAccelTime;

    //testowe prędkości
    [SerializeField]float maxSpeed = 15f;
    [SerializeField]float minSpeed = 3f;

    void Start()
    {
        currentSpeed = speed2;

        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<PolygonCollider2D>();
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;

            //kółka w dół
            wheel1Anim.SetBool("isJumping", false);
            wheel2Anim.SetBool("isJumping", false);
            wheel3Anim.SetBool("isJumping", false);
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            //kółka do góry
            wheel1Anim.SetBool("isJumping", true);
            wheel2Anim.SetBool("isJumping", true);
            wheel3Anim.SetBool("isJumping", true);
        }

        //--------MOJA PROPOZYCJA PRZYSPIESZANIA/SPOWALNIANIA-----------------
        if (Input.GetAxis("Horizontal") > 0 && currentSpeed <= maxSpeed && cam.orthographicSize <=12)
        {
            //testowo współczynnik przyspieszenia zahardcodowałem na 5, ale to kwestia do ustalenia
            currentSpeed += 5f * Time.deltaTime;
            cam.orthographicSize += 1f * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < 0 && currentSpeed >= minSpeed && cam.orthographicSize >= 6)
        {
            currentSpeed -= 5f * Time.deltaTime;
            cam.orthographicSize -= 1f * Time.deltaTime;
        }
        //--------------------------------------------------------------------

        /*
        if (Input.GetKeyDown(KeyCode.D))
        {
            hasPressedAccel = true;
            pressedAccelTime = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            hasPressedAccel = false;
            StopCoroutine("Accel");
        }
        if (grounded && hasPressedAccel && Time.time - pressedAccelTime > 0.5f)
        {
            StartCoroutine("Accel");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            hasPressedDeAccel = true;
            pressedDeAccelTime = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            hasPressedDeAccel = false;
            StopCoroutine("DeAccel");
        }
        if (grounded && hasPressedDeAccel && Time.time - pressedDeAccelTime > 0.5f)
        {
            StartCoroutine("DeAccel");
        }
        */
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire"))
        {
            _missile = Instantiate(missilePrefab, transform.position + transform.up * 2.0f, transform.rotation) as GameObject;
            _missile2 = Instantiate(missile2Prefab, transform.position + transform.right * 3.0f, transform.rotation) as GameObject;

            //w oryginale rakieta z przodu ma ograniczony zasięg, żeby nie mogła doleciec za daleko
            Destroy(_missile2, 0.6f);
        }

        CheckForHighscore();
    }

    IEnumerator Accel()
    {
        if (currentSpeed == speed1)
        {
            yield return new
            WaitForSeconds(0.5f);
            currentSpeed = speed2;
        }
        if (currentSpeed == speed2)
        {
            yield return new
            WaitForSeconds(0.5f);
            currentSpeed = speed3;
        }
        if (currentSpeed == speed3)
        {
            yield return new
            WaitForSeconds(0.5f);
            currentSpeed = speed4;
        }
        if (currentSpeed == speed4)
        {
            yield return new
            WaitForSeconds(0.5f);
            currentSpeed = speed5;
        }
        if (currentSpeed == speed5)
        {
            currentSpeed = speed5;
        }
        hasPressedAccel = false;
    }

    IEnumerator DeAccel()
    {
        if (currentSpeed == speed5)
        {
            yield return new
            WaitForSeconds(0.5f);
            currentSpeed = speed4;
        }
        if (currentSpeed == speed4)
        {
            yield return new
            WaitForSeconds(0.5f);
            currentSpeed = speed3;
        }
        if (currentSpeed == speed3)
        {
            yield return new
            WaitForSeconds(0.5f);
            currentSpeed = speed2;
        }
        if (currentSpeed == speed2)
        {
            yield return new
            WaitForSeconds(0.5f);
            currentSpeed = speed1;
        }
        if (currentSpeed == speed1)
        {
            currentSpeed = speed1;
        }
        hasPressedDeAccel = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Bomb _bomb = col.GetComponent<Bomb>();
        if (_bomb != null)
        {
            Destroy(this.gameObject);
        }
    }

    //utrata życia
    public void LooseLife()
    {
        GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
        lives--;

        if (lives > 0)
        {
            currentSpeed = speed2;
            //jeśli gracz wciąż ma jakieś życia to cofa go na pozycję ostatniego checkpointa
            transform.position = checkpoint.position;
        }
        else if (lives <= 0)
        {
            //jesli gracz nie ma juz żyć, trafia do sceny game over
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //sprawdzenie, czy highscore nie został pobity
    void CheckForHighscore ()
    {
        if  (score > highscore)
        {
            highscore = score;
        }
    }
}
