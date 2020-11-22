using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreEntry : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;

    void Start()
    {
        entryContainer = transform.Find("highscoreContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 33f;
        for (int i = 0; i <10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch(rank)
            {
                default:
                    rankString = rank + "TH";
                    break;
                case 1: 
                    rankString = "1ST";
                    break;
                case 2:
                    rankString = "2ND";
                    break;
                case 3:
                    rankString = "3RD";
                    break;
            }
            entryTransform.Find("positionTextTemp").GetComponent<TMPro.TextMeshProUGUI>().text = rankString;

            int score = Random.Range(0, 1000);
            entryTransform.Find("scoreTextTemp").GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();

            string name = "AAA";
            entryTransform.Find("nameTextTemp").GetComponent<TMPro.TextMeshProUGUI>().text = name;
        }

    }
}
