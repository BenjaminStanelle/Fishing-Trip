using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HookScript : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public AudioSource audio;
    public int NumberofSeconds = 8;
    public int IsRunning = 1, IsRunning1 = 1;
    Vector3 movement = new Vector3(-1, 0f, 0f);
    public float speed = 2, Volume;

    //Jeremy
    private Renderer rend;
    private BoxCollider2D collision;
    // end Jeremy


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

        //on collision, play sound, disable renderer and collider, then destroy object after sound.
        //Jeremy
        audio.PlayOneShot(SoundToPlay, Volume);
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        collision = GetComponent<BoxCollider2D>();
        collision.enabled = false;
        //end Jeremy

        //Destroy(this.gameObject);
        if (IsRunning1 == 1)
        {

            StartCoroutine(Wait1());

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
