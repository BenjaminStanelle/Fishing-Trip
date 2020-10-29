using System;
using UnityEngine;

public class AnimationControl: MonoBehaviour
{
    
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        Run(moveH);
        Jump();


    }

    public void Run(float moveH)
    {
        anim.SetInteger("Run", 2);
        if (Mathf.Abs(moveH) > 0)
        {
            if (moveH > 0)
                anim.speed = 1.5f;

            if (moveH < 0)
            {
                anim.speed = .5f;
            }

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






