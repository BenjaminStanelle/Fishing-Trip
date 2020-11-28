using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Create a new Dropdown GameObject by going to the Hierarchy and clicking Create>UI>Dropdown. Attach this script to the Dropdown GameObject.
//Set your own Text in the Inspector window
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
        PlayerPrefs.SetInt("Skin", change.value);
    }
}