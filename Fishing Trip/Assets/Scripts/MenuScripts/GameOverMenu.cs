using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    void Start()
    {
        AudioListener.pause = false;
    }
   
    public void PlayGame ()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
