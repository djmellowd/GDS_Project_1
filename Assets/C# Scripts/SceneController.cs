using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject Enemy02Prefab;
    private GameObject _enemy;
    private GameObject _enemy2;

    void Update()
    {
        if (_enemy == null && _enemy2 == null)
        {
            _enemy = Instantiate(Enemy02Prefab) as GameObject;
            _enemy.transform.position = new Vector3(-15, 9, 0);
            float angle = 0;
            _enemy.transform.Rotate(0, angle, 0);

            _enemy2 = Instantiate(Enemy02Prefab) as GameObject;
            _enemy2.transform.position = new Vector3(5, 9, 0);
            float angle2 = 0;
            _enemy2.transform.Rotate(0, angle2, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
