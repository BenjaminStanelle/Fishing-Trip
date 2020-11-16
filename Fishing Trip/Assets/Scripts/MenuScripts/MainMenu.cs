using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   
   void Start() 
   {
      Screen.orientation = ScreenOrientation.LandscapeLeft;
   }
   
   public void PlayGame ()
   {
	   SceneManager.LoadScene("GameScene");
   }
   
   public void QuitGame()
   {
	   Debug.Log("QUIT!");
	   Application.Quit();
   }
   
}
