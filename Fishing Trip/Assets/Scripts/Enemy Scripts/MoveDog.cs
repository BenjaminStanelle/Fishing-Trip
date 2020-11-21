using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class MoveDog : MonoBehaviour //rewritten by Jeremy
{
    Camera m_MainCamera;
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
        speed = MyPlayer.BaseSpeed * 1.8f;
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the dog right at speed based on player movement
        transform.Translate(movement * speed * Time.deltaTime);
        if (this.transform.position.x > (m_MainCamera.transform.position.x + 32) || this.transform.position.y < (m_MainCamera.transform.position.y - 15))
        {
            Destroy(this.gameObject);
        }
    }

    void CreateDust()
    {
        dust.Play();
    }
}
