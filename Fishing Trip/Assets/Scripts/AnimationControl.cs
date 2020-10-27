using System;
using UnityEngine;

public class AnimationControl: MonoBehaviour
{
    
    private Animator anim;
    private bool left;
    private bool right;
    private Rigidbody2D rb;




    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        right = true;
        left = false;
    }


    void Update()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        Run(moveH);
        Jump();


    }


    public void Run(float moveH)
    {
       
        if (moveH > 0)
            TurnRight();
        if (moveH < 0)
            TurnLeft();

        if (Mathf.Abs(moveH) > 0)
            anim.SetInteger("Run", 1);
        else
        {
            anim.SetInteger("Run", 0);
        }
    }

    public void TurnLeft ()
    {
        if (left == true)
            return;
        transform.localScale = new Vector3
            (-transform.localScale.x, transform.localScale.y,
            transform.localScale.z);
        left = true;
        right = false;

    }
    public void TurnRight()
    {
        if (right == true)
            return;
        transform.localScale = new Vector3
            (Mathf.Abs(transform.localScale.x), transform.localScale.y,
            transform.localScale.z);
        right = true;
        left = false;


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






