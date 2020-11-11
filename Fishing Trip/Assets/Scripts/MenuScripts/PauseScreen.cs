using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tia Benson

public class PauseScreen : MonoBehaviour
{
   [SerializeField] private AudioSource audio = null;

    public void onContinue()    //when play button pressed, continue audio and game
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        audio.Play(0);
    }
}
