using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetBait : MonoBehaviour
{

    int score = 0;
    private TMP_Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("BaitScore");
        textComponent = GetComponent<TMP_Text>();

        textComponent.text = score.ToString();
    }

}

