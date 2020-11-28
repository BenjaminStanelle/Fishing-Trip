using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSkin : MonoBehaviour
{
    string name = "";
    private TMP_Text textComponent;
    // Update is called once per frame
    void Update()
    { 
        textComponent = GetComponent<TMP_Text>();
        name = textComponent.text;

        PlayerPrefs.SetString("PlayerSkin", name);
    }
}