using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tia Benson

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    //[SerializeField] private AudioSource audio = null;


    void Awake() 
    {
        Time.timeScale = 1f;
    }

    public void onPause() //when pause button pressed, show pause screen & pause audio
    {
        gameMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
}
