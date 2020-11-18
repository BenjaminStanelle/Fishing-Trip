using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class MoveChicken : MonoBehaviour
{
    Camera m_MainCamera;
    public int NumberofSeconds;
    public int IsRunning = 1;
    Vector3 movement = new Vector3(-1, 0f, 0f);
    public float speed = 15;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
        anim = GetComponent<Animator>();
        anim.speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the bull left at certain speed
        transform.Translate(movement * speed * Time.deltaTime);
        if (this.transform.position.x < (m_MainCamera.transform.position.x - 33) || this.transform.position.y < (m_MainCamera.transform.position.y - 15))
        {
            Destroy(this.gameObject);
        }



    }


}
