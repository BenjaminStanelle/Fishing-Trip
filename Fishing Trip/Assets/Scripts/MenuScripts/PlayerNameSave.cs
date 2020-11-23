using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerNameSave : MonoBehaviour
{

    string name;
    private TMP_Text textComponent;

    void Update()
    {
        textComponent = GetComponent<TMP_Text>();
        name = textComponent.text;

        if (textComponent == null) ;
        else
        {
            PlayerPrefs.SetString("PlayerName", name);
        }
    }
}
