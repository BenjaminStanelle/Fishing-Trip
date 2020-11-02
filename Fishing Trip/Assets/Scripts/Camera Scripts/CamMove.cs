using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMove MyPlayer;

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
        rb.velocity = new Vector2(MyPlayer.BaseSpeed, 0);
    }
}
