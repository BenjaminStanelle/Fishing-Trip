using System;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float BaseSpeed = 10;
    public float AlterSpeed = 5;
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
        rb.velocity = new Vector2(BaseSpeed, rb.velocity.y); //Constant horizontal speed

        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveHorizontal, 0, 0) * Time.deltaTime * AlterSpeed;
        // slow down, speed up controls AKA left and right movement on the screen
    }
    
    private void Jump()
    { // If input keyboard is "Jump" and character is not in the air add force to jump up
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        

    }


}






