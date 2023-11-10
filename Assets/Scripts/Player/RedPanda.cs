using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPanda : Player
{
    private bool isClimbing = false;
    private bool isHalfway;
    private Vector2 groundNormal;
    private Vector2 velocity;
    //public BoxCollider2D boxCollider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Climbable"))
        {
            isClimbing = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Climbable"))
        {
            isClimbing = false;
        }
    }
   
    new public void Move(Vector2 movement)
    {
        /**if (isGrounded) //if not on slope
        {
            rb.velocity = new Vector2(speed * movement.x, 0.0f); 
        }
        else
        {
            rb.velocity = new Vector2(speed * movement.x, rb.velocity.y);
        }**/
        base.Move(movement);
    }
    

    

}
