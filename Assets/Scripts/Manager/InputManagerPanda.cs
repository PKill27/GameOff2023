using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerPanda : MonoBehaviour
{
   
   public RedPanda player;
   
    void Awake()
    {
        
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player.canJump)
            {
                player.Jump();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.isWalking = true;
            player.Move(Vector2.left); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.isWalking = true;
            player.Move(Vector2.right);
        }
        else
        {
            player.animator.SetBool("isWalking", false);
            player.isWalking = false;

        }
        
    }
    
}
