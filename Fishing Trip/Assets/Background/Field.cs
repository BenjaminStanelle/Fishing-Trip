using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private BoxCollider2D collider;     //bounds that determine when to reposition BG
    private Rigidbody2D rigid;     //allows for BG movement
    private float Vector_width = 0f;
    private float speed = -5f;  //speed of BG

    private void Infinite()   //Attach BG to the end sequence for infinite scrolling
    {
        Vector2 vector = new Vector2(Vector_width * 1.6f, 0); //get current size of backgrounds combined
        transform.position = (Vector2)transform.position + vector;  //add to end of BG list
    }

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();   //get BoxColliders & Rigibodies
        rigid = GetComponent<Rigidbody2D>();

        Vector_width = collider.size.x;
        rigid.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -Vector_width) //if collider is bypassed, reposition the BG to the end of the sequence
        {
            Infinite();
        }
    }
    
}
