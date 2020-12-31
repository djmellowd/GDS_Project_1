using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //liczba żyć gracza
    public int lives = 3;
    //ostatni zdobyty checkpoint
    public Transform checkpoint;

    [SerializeField] float speed = 5;
    [SerializeField] float maxSpeed = 20;
    [SerializeField] float minSpeed = 5;
    [SerializeField] float accelaration = 2;
    [SerializeField] float deaccelaration = -2;
    
    public float jumpForce = 18.0f;

    private Rigidbody2D _body;
    private PolygonCollider2D _box;

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject missile2Prefab;
    private GameObject _missile;
    private GameObject _missile2;

    void Start()
    {
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
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetAxis("Horizontal") > 0 && speed < maxSpeed && grounded)
        {
            transform.Translate(new Vector2(1, _body.velocity.y) * accelaration * Time.deltaTime);
            speed = speed + accelaration;
        }
        else if (Input.GetAxis("Horizontal") < 0 && speed > minSpeed && grounded)
        {
            transform.Translate(new Vector2(-1, _body.velocity.y) * deaccelaration * Time.deltaTime);
            speed = speed + deaccelaration;
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire"))
        {
            _missile = Instantiate(missilePrefab, transform.position + transform.up * 2.0f, transform.rotation) as GameObject;
            _missile2 = Instantiate(missile2Prefab, transform.position + transform.right * 3.0f, transform.rotation) as GameObject;
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
