using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPanda : Player
{
   
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
