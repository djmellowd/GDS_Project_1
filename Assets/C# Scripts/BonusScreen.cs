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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}
