using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        scoreText.text = "Your Score: " + Player.score.ToString();
        highscoreText.text = "Highscore: " + Player.highscore.ToString();
    }

    void Update()
    {
        //wciśnięcie escape powoduje powrót do ekranu startowego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
