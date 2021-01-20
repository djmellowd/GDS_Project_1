using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn15 : MonoBehaviour
{
    [SerializeField] private GameObject Enemy01Prefab;
    [SerializeField] private GameObject Enemy02Prefab;
    [SerializeField] private GameObject Enemy03Prefab;
    [SerializeField] private GameObject EnemyElitePrefab;
    private GameObject _enemy;
    private GameObject _enemy2;
    private GameObject _enemy3;
    private GameObject _enemy4;
    private GameObject _enemy5;
    private GameObject _enemy6;
    private GameObject _enemy7;
    private GameObject _enemy8;
    private GameObject _enemy9;
    private GameObject _enemy10;
    private GameObject _enemy11;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            NewEnemiesIII4();
        }
    }

    void NewEnemiesI2()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350, Screen.height - 150, 0));
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150, Screen.height - 150, 0));
        _enemy2.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesI3()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350, Screen.height - 150, 0));
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150, Screen.height - 150, 0));
        _enemy2.transform.Rotate(0, angle, 0);

        _enemy3 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy3.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250, Screen.height - 300, 0));
        _enemy3.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesI4()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350, Screen.height - 150, 0));
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150, Screen.height - 150, 0));
        _enemy2.transform.Rotate(0, angle, 0);

        _enemy3 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy3.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250, Screen.height - 300, 0));
        _enemy3.transform.Rotate(0, angle, 0);

        _enemy4 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy4.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1050, Screen.height - 300, 0));
        _enemy4.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesII2()
    {
        _enemy5 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy5.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350, Screen.height - 150, 0));
        float angle = 0;
        _enemy5.transform.Rotate(0, angle, 0);

        _enemy6 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy6.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150, Screen.height - 150, 0));
        _enemy6.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesII3()
    {
        _enemy5 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy5.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350, Screen.height - 150, 0));
        float angle = 0;
        _enemy5.transform.Rotate(0, angle, 0);

        _enemy6 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy6.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150, Screen.height - 150, 0));
        _enemy6.transform.Rotate(0, angle, 0);

        _enemy7 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy7.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250, Screen.height - 300, 0));
        _enemy7.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII2()
    {
        _enemy8 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy8.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350, Screen.height - 150, 0));
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy9.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150, Screen.height - 150, 0));
        _enemy9.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII3()
    {
        _enemy8 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy8.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350, Screen.height - 150, 0));
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy9.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150, Screen.height - 150, 0));
        _enemy9.transform.Rotate(0, angle, 0);

        _enemy10 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy10.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250, Screen.height - 300, 0));
        _enemy10.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII4()
    {
        _enemy8 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy8.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350, Screen.height - 150, 0));
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy9.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150, Screen.height - 150, 0));
        _enemy9.transform.Rotate(0, angle, 0);

        _enemy10 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy10.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250, Screen.height - 300, 0));
        _enemy10.transform.Rotate(0, angle, 0);

        _enemy11 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy11.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1050, Screen.height - 300, 0));
        _enemy11.transform.Rotate(0, angle, 0);
    }
}
