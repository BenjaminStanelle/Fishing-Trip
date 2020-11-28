using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    public float BaseSpeed = 10;
    public float AlterSpeed = 10;
    public float jumpForce = 10;
    public Rigidbody2D rb;
    private int distance = 0;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DistanceScore.score = 0;
        BaitScore.score = 0;
    }


    void Update()
    {
        // For distance score
        distance = (int) (rb.transform.position.x)/50;
        DistanceScore.score = distance;
    }

    void FixedUpdate() 
    {
        moveHorizontal();
        Jump();
    }

    public void moveHorizontal()
    {
        rb.velocity = new Vector2(BaseSpeed, rb.velocity.y); //Constant horizontal speed

        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        transform.position += new Vector3(moveHorizontal, 0, moveVertical) * Time.deltaTime * AlterSpeed;
        // slow down, speed up controls AKA left and right movement on the screen
    }
    
    
    public void Jump()
    { // If input keyboard is "Jump" and character is not in the air add force to jump up
        if (CrossPlatformInputManager.GetButton("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            //rb.AddForce(new Vector2(0f, jumpForce*3.2f), ForceMode2D.Impulse);
           // rb.velocity = Vector2.up * jumpForce*3.4f;
            rb.AddForce(Vector3.up*jumpForce*3.4f, ForceMode2D.Impulse);
        
            
    }
}






