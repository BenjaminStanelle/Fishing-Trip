using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorderObject1 : MonoBehaviour
{
    private Vector2 screenBounds;
    private Rigidbody2D rb;

    public PlayerMove MyPlayer;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(screenBounds.x*-1, screenBounds.y, 0);
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
