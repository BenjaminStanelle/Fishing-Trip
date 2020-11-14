﻿using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    public float BaseSpeed = 10;
    public float AlterSpeed = 5;
    public float jumpForce = 10;
    public Rigidbody2D rb;
    private int distance = 0;
    private float boostTimer;
    private bool boosting;
    Renderer ren;
    Color color;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boostTimer = 0;
        boosting = false;
        ren = GetComponent<Renderer>();
        color = ren.material.color;
    }


    void Update()
    {
        moveHorizontal();
        Jump();
    
        // For distance score
        distance = (int)(rb.transform.position.x)/100;
        DistanceScore.score = distance;
        // For speed boost effect when collide with coffee
        if(boosting)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer>=5)
            {
                boostTimer = 0;
                BaseSpeed = 10;
                boosting = false;
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coffee")
        {
            boosting = true;
            BaseSpeed = 50;
        }
        if (other.gameObject.tag == "hook")
        {
            StartCoroutine("GoInvisible");
        }
    }

    // Invisible effect when collide with hook
    public IEnumerator GoInvisible()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        color.a = 0.5f;
        ren.material.color = color;
        yield return new WaitForSeconds(5f);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        color.a = 1f;
        ren.material.color = color;


    }


    public void moveHorizontal()
    {
        rb.velocity = new Vector2(BaseSpeed, rb.velocity.y); //Constant horizontal speed

        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        transform.position += new Vector3(moveHorizontal, 0, 0) * Time.deltaTime * AlterSpeed;
        // slow down, speed up controls AKA left and right movement on the screen
    }
    
    
    public void Jump()
    { // If input keyboard is "Jump" and character is not in the air add force to jump up
        if (CrossPlatformInputManager.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            rb.AddForce(new Vector2(0f, jumpForce*3.1f), ForceMode2D.Impulse);
        

    }
    

}






