using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tia Benson

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    [SerializeField] private AudioSource audio = null;

    public void onPause() //when pause button pressed, show pause screen & pause audio
    {
        gameMenu.SetActive(true);
        Time.timeScale = 0f;
        audio.Pause();
    }
}
