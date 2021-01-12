using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusScreen : MonoBehaviour
{
    public TextMeshProUGUI playerTimeText;
    public TextMeshProUGUI averageTimeText;
    public TextMeshProUGUI recordTimeText;
    public TextMeshProUGUI bonusText;

    HUDController hudController;

    // Start is called before the first frame update
    void Start()
    {
        hudController = FindObjectOfType<HUDController>();

        playerTimeText.text = ((int)hudController.timer).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            hudController.timer = 0f;
            gameObject.SetActive(false);
        }
    }
}
