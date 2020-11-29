using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinDropdown : MonoBehaviour
{
    private TMPro.TMP_Dropdown myDropdown;

    void Start()
    {
        //Fetch the Dropdown GameObject
        myDropdown = GetComponent<TMPro.TMP_Dropdown>();
        //Add listener for when the dropdown is changed
        myDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(myDropdown);
        });
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(TMPro.TMP_Dropdown change)
    {
        PlayerPrefs.SetInt("Skin", change.value);//Save selected skin to playerprefs
    }
}