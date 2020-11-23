using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetTotal : MonoBehaviour
{

    int score = 0;
    int bait = 0;
    private TMP_Text textComponent;
    // Start is called before the first frame update
    void Start()
    {

        score = PlayerPrefs.GetInt("DistanceScore");
        bait = PlayerPrefs.GetInt("BaitScore");
        textComponent = GetComponent<TMP_Text>();

        textComponent.text = (score + bait).ToString();

    }

}
