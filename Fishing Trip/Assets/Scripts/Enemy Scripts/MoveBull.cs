using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class MoveBull : MonoBehaviour
{
    Camera m_MainCamera;
    public int NumberofSeconds;
    public int IsRunning = 1;

    public ParticleSystem dust;
    Vector3 movement = new Vector3(-1, 0f, 0f);
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
        CreateDust();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the bull left at certain speed
        transform.Translate(movement * speed * Time.deltaTime);
        if (this.transform.position.x < (m_MainCamera.transform.position.x - 40) || this.transform.position.y < (m_MainCamera.transform.position.y - 15))
        {
            Destroy(this.gameObject);
        }

    }

    void CreateDust()
    {
        dust.Play();
    }

  

}
