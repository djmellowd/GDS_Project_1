using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CautionScanner : MonoBehaviour
{
    public GameObject enemyCautionSprite;
    public GameObject rockCautionSprite;
    public GameObject mineCautionSprite;
    public TextMeshProUGUI cautionText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11) // enemy
        {
            enemyCautionSprite.SetActive(true);
            cautionText.text = "Enemy Attack";
        }
        if (collision.gameObject.layer == 15) // obstacle
        {
            rockCautionSprite.SetActive(true);
            cautionText.text = "Rocks Ahead";
        }
        if (collision.gameObject.layer == 16) //mines
        {
            mineCautionSprite.SetActive(true);
            cautionText.text = "Minefield Ahead";
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11) // enemy
        {
            enemyCautionSprite.SetActive(false);
            cautionText.text = " ";
        }
        if (collision.gameObject.layer == 15) // obstacle
        {
            rockCautionSprite.SetActive(false);
            cautionText.text = " ";
        }
        if (collision.gameObject.layer == 16) //mines
        {
            mineCautionSprite.SetActive(false);
            cautionText.text = " ";
        }
    }
}
