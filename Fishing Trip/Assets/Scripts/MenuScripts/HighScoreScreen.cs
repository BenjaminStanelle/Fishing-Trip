using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreScreen : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate; 
    private List<Transform> highscoreEntryTransformList;

    void Start()
    {
        entryContainer = transform.Find("highscoreContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("highscoreTable"))
        {

        } else
        {
            DefaultHighScores();
        }

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        int newScore = PlayerPrefs.GetInt("DistanceScore") + PlayerPrefs.GetInt("BaitScore");
        string name = PlayerPrefs.GetString("PlayerName");
        int count = 9;
        int score = highscores.highscoreEntryList[0].score;

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            if (score >= highscores.highscoreEntryList[i].score)
            {
                count = i - 1;
                score = highscores.highscoreEntryList[i].score;
            }
        }

        if (highscores.highscoreEntryList.Count < 10)
        {
            AddHighscoreEntry(newScore, name);
        }
        else if (newScore > score)
        {
            ReplaceHighscoreEntry(newScore, name, count);
        }

        jsonString = PlayerPrefs.GetString("highscoreTable");
        highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
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

        PlayerPrefs.SetInt("DistanceScore", 0);
        PlayerPrefs.SetInt("BaitScore", 0);

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

    private void ReplaceHighscoreEntry(int score, string name, int count)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.RemoveAt(count);
        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private void DefaultHighScores()
    {
        List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ score = 1000, name = "Alex"},
            new HighscoreEntry{ score = 999, name = "Uyen"},
            new HighscoreEntry{ score = 777, name = "Tia"},
            new HighscoreEntry{ score = 778, name = "Ben"},
            new HighscoreEntry{ score = 666, name = "Jeremy"},
        };

        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
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

