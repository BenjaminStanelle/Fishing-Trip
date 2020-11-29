using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckName : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject gameOverScreen;
    public GameObject enterNameMenu;
    public GameObject enterNameScreen;
    public GameObject highScoreMenu;
    public GameObject highScoreScreen;

    public void CheckNameOnClick()
    {
        if(PlayerPrefs.HasKey("PlayerName") || PlayerPrefs.GetString("PlayerName") == "")
        {
            enterNameMenu.gameObject.SetActive(true);
            enterNameScreen.gameObject.SetActive(true);
        } else
        {
            highScoreMenu.gameObject.SetActive(true);
            highScoreScreen.gameObject.SetActive(true);
        }
        gameOverMenu.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
    }
}
