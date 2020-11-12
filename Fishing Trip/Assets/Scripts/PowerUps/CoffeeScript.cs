using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class CoffeeScript : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public AudioSource audio;
    public int NumberofSeconds = 8;
    public int IsRunning = 1, IsRunning1 = 1;
    Vector3 movement = new Vector3(-1, 0f, 0f);
    public float speed = 2, Volume;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * Time.deltaTime);

        if (IsRunning == 1)
        {
            StartCoroutine(Wait());
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        //if its a player kill the player then switch to menu
        if (other.gameObject.tag == "Player")
        {
            audio.PlayOneShot(SoundToPlay, Volume);
            //power up effect goes here.
            //Destroy(this.gameObject);
            if (IsRunning1 == 1)
            {
                StartCoroutine(Wait1());
            }
        }
    }


    public IEnumerator Wait()
    {
        //in case the player doesn't touch the coffee
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        Destroy(this.gameObject);
        IsRunning = 1;
    }

    public IEnumerator Wait1()
    {
        //The object needs to stay around just long enough to play the sound effect.
        IsRunning1 = 0;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        IsRunning1 = 1;
    }
}
