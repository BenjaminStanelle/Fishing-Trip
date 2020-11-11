using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundFX : MonoBehaviour
{
    
    private AudioSource track;


    void Start()
    {
        track = GetComponent<AudioSource>();
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            track.Play();
            float wait = track.clip.length;
            Destroy(gameObject,wait);
        }
            

    }
   
   

}
