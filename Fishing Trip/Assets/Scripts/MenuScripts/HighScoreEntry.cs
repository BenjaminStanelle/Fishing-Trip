using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }

    }
}
