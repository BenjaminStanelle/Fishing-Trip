using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMove MyPlayer;

    public int IsBG = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyPlayer = FindObjectOfType<PlayerMove>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2((MyPlayer.BaseSpeed)/(IsBG+1), 0); 
        //IsBG=1 for yes, 0 for no. This slows down the background to give a different perspective of distance traveled. 1 is added to prevent divide by 0.
    }
}
