using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreEntry : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    void Start()
    {
        entryContainer = transform.Find("highscoreContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        /*
        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ score = 1000, name = "Alex"},
            new HighscoreEntry{ score = 999, name = "Uyen"},
            new HighscoreEntry{ score = 777, name = "Tia"},
            new HighscoreEntry{ score = 778, name = "Ben"},
            new HighscoreEntry{ score = 666, name = "Jeremy"},
        };
        */

        //AddHighscoreEntry(10000, "Hi");
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        

        for(int i = 0; i <highscores.highscoreEntryList.Count; i++)
        {
            for(int j = i+1; j < highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        /*
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        */

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 33f;
 
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;
            switch (rank)
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

            int score = highscoreEntry.score;
            entryTransform.Find("scoreTextTemp").GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();

            string name = highscoreEntry.name;
            entryTransform.Find("nameTextTemp").GetComponent<TMPro.TextMeshProUGUI>().text = name;

            transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
