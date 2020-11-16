using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private bool invincible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if pplayer is immune, destroy obstacle
        if (other.gameObject.tag == "Enemy" && invincible)
        {
            Destroy(other.gameObject);
            invincible = false;
        }
        //if player is not immune, end game
        else if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("MainMenu");
        }
        //if player collects hook, turn immune
        else if (other.gameObject.tag == "hook")
        {
            invincible=true;
        }
    }
}
