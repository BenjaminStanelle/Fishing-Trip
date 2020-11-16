using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class DistanceScore : MonoBehaviour
{
    public static int score = 0;
    private TMP_Text textComponent;
    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();

    }

    private void Update()
    {
        textComponent.text = "Distance " + score.ToString();
    }
}

