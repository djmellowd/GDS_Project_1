using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    public GameObject _enemy;
    public GameObject _enemy2;

    void Update()
    {
        if (_enemy == null && _enemy2 == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(-15, 4, 0);
            float angle = 0;
            _enemy.transform.Rotate(0, angle, 0);

            _enemy2 = Instantiate(enemyPrefab) as GameObject;
            _enemy2.transform.position = new Vector3(15, 4, 0);
            float angle2 = 180;
            _enemy2.transform.Rotate(0, angle2, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
