using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreDefault : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highscoreTable"))
        {

        }
        else
        {
            DefaultHighScores();
        }
    }

    private void DefaultHighScores()
    {
        List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ score = 100, name = "Alex"},
            new HighscoreEntry{ score = 90, name = "Uyen"},
            new HighscoreEntry{ score = 80, name = "Tia"},
            new HighscoreEntry{ score = 70, name = "Ben"},
            new HighscoreEntry{ score = 60, name = "Jeremy"},
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
