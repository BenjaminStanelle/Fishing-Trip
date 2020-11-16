using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class MoveDog : MonoBehaviour //rewritten by Jeremy
{
    public int NumberofSeconds;
    public int IsRunning = 1;
    public ParticleSystem dust;
    Vector3 movement = new Vector3(1, 0f, 0f);
    public float speed;
    private PlayerMove MyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        CreateDust();
        MyPlayer = FindObjectOfType<PlayerMove>();
        speed = MyPlayer.BaseSpeed * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the dog right at speed based on player movement
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void CreateDust()
    {
        dust.Play();
    }
}
