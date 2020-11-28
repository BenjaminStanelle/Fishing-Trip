using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerNameSave : MonoBehaviour
{

    string name = "";
    private Text textComponent;

    void Update()
    {
        textComponent = GetComponent<Text>();
        name = textComponent.text;

        PlayerPrefs.SetString("PlayerName", name);
    }
}
