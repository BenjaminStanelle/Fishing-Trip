using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayPlayerName : MonoBehaviour
{
    string name = "";
    private Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            textComponent.text = PlayerPrefs.GetString("PlayerName");
        } else
        {
            textComponent.text = "Enter Name";
        }
    }
}
