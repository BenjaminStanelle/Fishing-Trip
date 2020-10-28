using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10;
    private Rigidbody2D rb;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        moveHorizontal();
        Jump();


    }

    private void moveHorizontal()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveHorizontal, 0, 0) * Time.deltaTime * speed;
    }
    private void Jump()
    { 
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        

    }


}






