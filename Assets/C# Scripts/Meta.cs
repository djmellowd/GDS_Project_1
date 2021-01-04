using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //sprawdzam czy kolidujący obiekt to gracz - warstwa o nazwie Player ma numer 10
        if (collision.gameObject.layer == 10)
        {
            //bonus 5000 za dotarcie do końca
            Player.score += 5000;
            //ładowanko ekranu końcowego
            SceneManager.LoadScene("EndGameScene");
        }
    }
}
