using UnityEngine;
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

    private bool hasPressedAccel;
    private bool hasPressedDeAccel;
    private float pressedAccelTime;
    private float pressedDeAccelTime;

    void Start()
    {
        currentSpeed = speed2;

        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<PolygonCollider2D>();
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

        if (Input.GetKeyDown(KeyCode.D))
        {
            hasPressedAccel = true;
            pressedAccelTime = Time.time;
        }
        if (grounded && hasPressedAccel && Time.time - pressedAccelTime > 0.5f)
        {
            if (currentSpeed == speed2)
            {
                currentSpeed = speed3;
            }
            else if (currentSpeed == speed3)
            {
                currentSpeed = speed4;
            }
            else if (currentSpeed == speed4)
            {
                currentSpeed = speed5;
            }
            else if (currentSpeed == speed5)
            {
                currentSpeed = speed5;
            }
            else if (currentSpeed == speed1)
            {
                currentSpeed = speed2;
            }
            hasPressedAccel = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            hasPressedDeAccel = true;
            pressedDeAccelTime = Time.time;
        }
        if (grounded && hasPressedDeAccel && Time.time - pressedDeAccelTime > 0.5f)
        {
            if (currentSpeed == speed2)
            {
                currentSpeed = speed1;
            }
            else if (currentSpeed == speed3)
            {
                currentSpeed = speed2;
            }
            else if (currentSpeed == speed4)
            {
                currentSpeed = speed3;
            }
            else if (currentSpeed == speed5)
            {
                currentSpeed = speed4;
            }
            else if (currentSpeed == speed1)
            {
                currentSpeed = speed1;
            }
            hasPressedDeAccel = false;
        }
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
