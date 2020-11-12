using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class BaitScript : MonoBehaviour
{
    public static int bonusScore = 0;
    public AudioClip SoundToPlay;
    public AudioSource audio;
    public int NumberofSeconds = 8;
    public int IsRunning = 1, IsRunning1 = 1;
    Vector3 movement = new Vector3(-1, 0f, 0f);
    public float speed = 2, Volume;
<<<<<<< HEAD

    private Renderer rend; //Jeremy

=======
>>>>>>> parent of 43ba8b3c... Improving Baitscript
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

<<<<<<< HEAD
<<<<<<< HEAD
        //on collision, play sound, disable renderer and collider, then destroy object after sound.
=======
        //if its a player, play sound, disable renderer, then destroy object after sound.
>>>>>>> parent of 1ed7bcc7... Powerup Script fixes, Animation Control Fixes
        //Jeremy
        audio.PlayOneShot(SoundToPlay, Volume);
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        // Add 1 point for each collision with powerUps
        BaitScore.score += 1;
        //end Jeremy

        //Destroy(this.gameObject);
        if (IsRunning1 == 1)
=======
        //if its a player kill the player then switch to menu
        if (other.gameObject.tag == "Player")
>>>>>>> parent of 43ba8b3c... Improving Baitscript
        {
            audio.PlayOneShot(SoundToPlay, Volume);
            // Add 1 point for each collision with powerUps
            bonusScore += 1;
            BaitScore.score = bonusScore;
           

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
