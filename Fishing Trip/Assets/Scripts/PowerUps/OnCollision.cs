using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detach");
        if (collision.gameObject.tag =="Player")
        {
            Destroy(this.gameObject); 
        }
        else
        {
            Destroy(this.gameObject,5);
        }
      

    }
    

}
