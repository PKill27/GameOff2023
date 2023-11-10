using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentTile : MonoBehaviour
{
    public BoxCollider2D coll;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Player.instance.rb.velocityY <= 0)
            {
                coll.isTrigger = false;
            }
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hloooo");
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.isGrounded = true;

        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        coll.isTrigger = true;
    }
   
}
