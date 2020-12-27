using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

    //odwołanie do ekranu pauzy
    public GameObject pausePanel;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                //wyświetlenie ekranu pauzy
                pausePanel.SetActive(true);

                Time.timeScale = 0;
                
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;

                //ukrycie ekranu pauzy
                pausePanel.SetActive(false);
            }
        }
    }
}
