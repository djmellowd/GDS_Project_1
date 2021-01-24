using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
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

    [SerializeField] private int choice;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            switch (choice)
            {
                case 0:
                    NewEnemiesI2();
                    break;
                case 1:
                    NewEnemiesI2();
                    break;
                case 2:
                    NewEnemiesII2();
                    break;
                case 3:
                    NewEnemiesI2();
                    break;
                case 4:
                    NewEnemiesII3();
                    break;
                case 5:
                    NewEnemiesIII2();
                    break;
                case 6:
                    NewEnemiesI2();
                    break;
                case 7:
                    NewEnemiesIII2();
                    break;
                case 8:
                    NewEnemiesII3();
                    break;
                case 9:
                    NewEnemiesI3();
                    break;
                case 10:
                    NewEnemiesIII2();
                    break;
                case 11:
                    NewEnemiesI2();
                    break;
                case 12:
                    NewEnemiesIII3();
                    break;
                case 13:
                    NewEnemiesII3();
                    break;
                case 14:
                    NewEnemiesI4();
                    break;
                case 15:
                    NewEnemiesIII4();
                    break;
                case 16:
                    NewEnemiesII3();
                    break;
            }
        }
    }

    void NewEnemiesI2()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350 * Random.Range(0.9f, 1f), Screen.height - -150, 0));
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150 * Random.Range(0.9f, 1f), Screen.height - -150, 0));
        _enemy2.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesI3()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350 * Random.Range(0.9f, 1f), Screen.height - -150, 0));
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150 * Random.Range(0.9f, 1f), Screen.height - -150, 0));
        _enemy2.transform.Rotate(0, angle, 0);

        _enemy3 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy3.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250 * Random.Range(0.9f, 1f), Screen.height - 0, 0));
        _enemy3.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesI4()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350 * Random.Range(0.9f, 1f), Screen.height - -150, 0));
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150 * Random.Range(0.9f, 1f), Screen.height - -150, 0));
        _enemy2.transform.Rotate(0, angle, 0);

        _enemy3 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy3.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250 * Random.Range(0.9f, 1f), Screen.height - 0, 0));
        _enemy3.transform.Rotate(0, angle, 0);

        _enemy4 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy4.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1050 * Random.Range(0.8f, 1f), Screen.height - 0, 0));
        _enemy4.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesII2()
    {
        _enemy5 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy5.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        float angle = 0;
        _enemy5.transform.Rotate(0, angle, 0);

        _enemy6 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy6.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        _enemy6.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesII3()
    {
        _enemy5 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy5.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        float angle = 0;
        _enemy5.transform.Rotate(0, angle, 0);

        _enemy6 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy6.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        _enemy6.transform.Rotate(0, angle, 0);

        _enemy7 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy7.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250 * Random.Range(0.8f, 1f), Screen.height - 0, 0));
        _enemy7.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII2()
    {
        _enemy8 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy8.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy9.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        _enemy9.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII3()
    {
        _enemy8 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy8.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy9.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        _enemy9.transform.Rotate(0, angle, 0);

        _enemy10 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy10.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250 * Random.Range(0.8f, 1f), Screen.height - 0, 0));
        _enemy10.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII4()
    {
        _enemy8 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy8.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1350 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy9.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1150 * Random.Range(0.8f, 1f), Screen.height - -150, 0));
        _enemy9.transform.Rotate(0, angle, 0);

        _enemy10 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy10.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1250 * Random.Range(0.8f, 1f), Screen.height - 0, 0));
        _enemy10.transform.Rotate(0, angle, 0);

        _enemy11 = Instantiate(EnemyElitePrefab) as GameObject;
        _enemy11.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1050 * Random.Range(0.8f, 1f), Screen.height - 0, 0));
        _enemy11.transform.Rotate(0, angle, 0);
    }
}
