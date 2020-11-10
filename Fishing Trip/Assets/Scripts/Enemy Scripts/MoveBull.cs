using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class MoveBull : MonoBehaviour
{
    public ParticleSystem dust;
    Vector3 movement = new Vector3(-1, 0f, 0f);
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        CreateDust();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the bull left at certain speed
        transform.Translate(movement * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if its a player kill the player then switch to menu
        if (other.gameObject.tag == "Player") ;
        {
            Destroy(other.gameObject);
            //UnloadSceneAsync("SampleScene");
            SceneManager.LoadScene("MainMenu");

        }
    }
    void CreateDust()
    {
        dust.Play();
    }

}
