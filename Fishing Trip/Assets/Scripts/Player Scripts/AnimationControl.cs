using System;
using UnityEngine;

public class AnimationControl: MonoBehaviour
{
    
    private Animator anim;

    private void Start()
    {
        // Get Animator component when game start
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        // Get input from horizontal axis
        float moveH = Input.GetAxisRaw("Horizontal");
        // Call function Run() with passed in value from horizontal input value 
        Run(moveH);
        // Call functioJump()
        Jump();


    }

    public void Run(float moveH)
    {
        // If there is movement from horizontal axis
        // Set animator "Run" parameter to "2" to play "GoRight" clip
        anim.SetInteger("Run", 2);
        if (Mathf.Abs(moveH) > 0)
        {
            // If character move right, set speed = 1.5f to go faster than default speed
            if (moveH > 0)
                anim.speed = 1.5f;
            // If character move left, set speed = .5f to go slower than default speed
            if (moveH < 0)
            {
                anim.speed = .5f;
            }
        }
        else
        {
            // set default speed = 1f
            anim.speed = 1f;
        }
        //original movement code for testing animations
        /*if (Mathf.Abs(moveH)>0)
        {
            if (moveH > 0)
                anim.SetInteger("Run", 2);

            if (moveH < 0)
            {
                anim.SetInteger("Run", 1);
            }

        }
        else
            
            anim.SetInteger("Run", 0);*/

    }
   
    public void Jump()
    {
        // Check if input is "Jump"
        // set animator parameter "Jump" to 1 to play "Jump" clip
        // otherwise, set "Jump" to 0 to go back to default clip
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetInteger("Jump", 1);
        }
        else
        {
            anim.SetInteger("Jump", 0);
        }
          

    }



}






