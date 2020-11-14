using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class MoveDog : MonoBehaviour
{
    public int NumberofSeconds;
    public int IsRunning = 1;
    public ParticleSystem dust;
    Vector3 movement = new Vector3(1, 0f, 0f);
    private float speed;
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
        //Move the bull left at certain speed
        transform.Translate(movement * speed * Time.deltaTime);

        if (IsRunning == 1)
        {
            StartCoroutine(Wait());
        }

    }

    void CreateDust()
    {
        dust.Play();
    }

    public IEnumerator Wait()
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        Destroy(this.gameObject);
        IsRunning = 1;
    }
}
