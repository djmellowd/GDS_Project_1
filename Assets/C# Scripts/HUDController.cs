using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI stageText;
    public Image progressBar;
    public Image live1;
    public Image live2;
    public Image live3;
    public string stage;

    [SerializeField] Transform startGamePoint;
    Meta endGamePoint;
    Player player;

    float gameLength;
    float playerDistance;
    float distanceDifference;


    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        endGamePoint = FindObjectOfType<Meta>();
        stage = " ";
        gameLength = Mathf.Abs(endGamePoint.transform.position.x - startGamePoint.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        //counting time
        timer += Time.deltaTime;

        timeText.text = "TIME " + ((int)timer).ToString();
        scoreText.text = Player.score.ToString();
        highscoreText.text = Player.highscore.ToString();
        stageText.text = "STAGE " + stage;
        ManageLives();
        CountDistance();
    }

    void CountDistance()
    {
        playerDistance = Mathf.Abs(endGamePoint.transform.position.x - player.transform.position.x);
        distanceDifference = gameLength - playerDistance;

        progressBar.rectTransform.localScale = new Vector3(distanceDifference / gameLength,1,1);
    }

    void ManageLives()
    {
        livesText.text = player.lives.ToString();

        if (player.lives == 2)
        {
            live3.enabled = false;
        }
        else if (player.lives == 1)
        {
            live2.enabled = false;
        }
        else if(player.lives <= 0)
        {
            live1.enabled = false;
        }
    }
}
