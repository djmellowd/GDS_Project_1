using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject Enemy01Prefab;
    [SerializeField] private GameObject Enemy02Prefab;
    [SerializeField] private GameObject Enemy03Prefab;
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


    void Start()
    {
        //zerowanie wyniku na starcie
        Player.score = 0;

        Invoke("NewEnemiesI2", 1);
        Invoke("NewEnemiesI2", 14);
        Invoke("NewEnemiesII2", 19);
        Invoke("NewEnemiesI2", 25);
        Invoke("NewEnemiesII3", 41);
        Invoke("NewEnemiesIII2", 48);
        Invoke("NewEnemiesI2", 53);
        Invoke("NewEnemiesIII2", 62);
        Invoke("NewEnemiesII3", 65);
        Invoke("NewEnemiesI3", 68);
        Invoke("NewEnemiesIII2", 95);
        Invoke("NewEnemiesI2", 101);
        Invoke("NewEnemiesIII3", 107);
        Invoke("NewEnemiesII3", 168);
        Invoke("NewEnemiesI4", 172);
        Invoke("NewEnemiesIII4", 179);
        Invoke("NewEnemiesII3", 183);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }

    void NewEnemiesI2()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = new Vector3(-15, 9, 0);
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = new Vector3(5, 9, 0);
        _enemy2.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesI3()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = new Vector3(-15, 9, 0);
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = new Vector3(5, 9, 0);
        _enemy2.transform.Rotate(0, angle, 0);

        _enemy3 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy3.transform.position = new Vector3(0, 9, 0);
        _enemy3.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesI4()
    {
        _enemy = Instantiate(Enemy01Prefab) as GameObject;
        _enemy.transform.position = new Vector3(-15, 9, 0);
        float angle = 0;
        _enemy.transform.Rotate(0, angle, 0);

        _enemy2 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy2.transform.position = new Vector3(5, 9, 0);
        _enemy2.transform.Rotate(0, angle, 0);

        _enemy3 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy3.transform.position = new Vector3(0, 9, 0);
        _enemy3.transform.Rotate(0, angle, 0);

        _enemy4 = Instantiate(Enemy01Prefab) as GameObject;
        _enemy4.transform.position = new Vector3(-10, 9, 0);
        _enemy4.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesII2()
    {
        _enemy5 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy5.transform.position = new Vector3(-15, 9, 0);
        float angle = 0;
        _enemy5.transform.Rotate(0, angle, 0);

        _enemy6 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy6.transform.position = new Vector3(5, 9, 0);
        _enemy6.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesII3()
    {
        _enemy5 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy5.transform.position = new Vector3(-15, 9, 0);
        float angle = 0;
        _enemy5.transform.Rotate(0, angle, 0);

        _enemy6 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy6.transform.position = new Vector3(5, 9, 0);
        _enemy6.transform.Rotate(0, angle, 0);

        _enemy7 = Instantiate(Enemy02Prefab) as GameObject;
        _enemy7.transform.position = new Vector3(0, 9, 0);
        _enemy7.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII2()
    {
        _enemy8 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy8.transform.position = new Vector3(-15, 9, 0);
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy9.transform.position = new Vector3(5, 9, 0);
        _enemy9.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII3()
    {
        _enemy8 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy8.transform.position = new Vector3(-15, 9, 0);
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy9.transform.position = new Vector3(5, 9, 0);
        _enemy9.transform.Rotate(0, angle, 0);

        _enemy10 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy10.transform.position = new Vector3(0, 9, 0);
        _enemy10.transform.Rotate(0, angle, 0);
    }

    void NewEnemiesIII4()
    {
        _enemy8 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy8.transform.position = new Vector3(-15, 9, 0);
        float angle = 0;
        _enemy8.transform.Rotate(0, angle, 0);

        _enemy9 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy9.transform.position = new Vector3(5, 9, 0);
        _enemy9.transform.Rotate(0, angle, 0);

        _enemy10 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy10.transform.position = new Vector3(0, 9, 0);
        _enemy10.transform.Rotate(0, angle, 0);

        _enemy11 = Instantiate(Enemy03Prefab) as GameObject;
        _enemy11.transform.position = new Vector3(-10, 9, 0);
        _enemy11.transform.Rotate(0, angle, 0);
    }
}
