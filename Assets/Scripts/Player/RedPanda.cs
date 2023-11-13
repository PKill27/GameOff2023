using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPanda : Player
{
    private bool isClimbing = false;
    private bool isHalfway;
    private Vector2 groundNormal;
    private Vector2 velocity;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
   
    new public void Move(Vector2 movement)
    { 
        base.Move(movement);
    }
    

    

}
