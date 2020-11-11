﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class PowerUpsV2 : MonoBehaviour
{
    public int NumberofSeconds = 8;
    public int IsRunning = 1;
    Vector3 movement = new Vector3(-1, 0f, 0f);
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move the bull left at certain speed
        transform.Translate(movement * speed * Time.deltaTime);

        if (IsRunning == 1)
        {
            StartCoroutine(Wait());
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if its a player kill the player then switch to menu
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //UnloadSceneAsync("SampleScene");
            
        }
    }


    public IEnumerator Wait()
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        Destroy(this.gameObject);
        IsRunning = 1;
    }
}
