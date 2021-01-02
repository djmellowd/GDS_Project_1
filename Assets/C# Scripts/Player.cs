using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
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
    
    public float jumpForce = 18.0f;

    private Rigidbody2D _body;
    public PolygonCollider2D _box;

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject missile2Prefab;
    private GameObject _missile;
    private GameObject _missile2;

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
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            _body.velocity = new Vector2(currentSpeed, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.D))
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
        }
        else if (Input.GetKeyDown(KeyCode.A))
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
        }
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire"))
        {
            _missile = Instantiate(missilePrefab, transform.position + transform.up * 2.0f, transform.rotation) as GameObject;
            _missile2 = Instantiate(missile2Prefab, transform.position + transform.right * 3.0f, transform.rotation) as GameObject;

            //w oryginale rakieta z przodu ma ograniczony zasięg, żeby nie mogła doleciec za daleko
            Destroy(_missile2, 0.6f);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Bomb _bomb = col.GetComponent<Bomb>();
        if (_bomb != null)
        {
            Destroy(this.gameObject);
        }
    }

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
}
