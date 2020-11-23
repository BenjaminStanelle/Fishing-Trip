using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class BaitScore : MonoBehaviour
{
    public static int score = 0 ;
    private TMP_Text textComponent;
    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();

      
    }

    private void Update()
    {
        textComponent.text = "Bait "+ score.ToString();
        PlayerPrefs.SetInt("BaitScore", score);
    }
}

