using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Tia

public class Menu : MonoBehaviour
{

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
}
