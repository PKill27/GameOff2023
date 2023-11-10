using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputManager instance;
    public RedPanda player;
    public Camera mainCamera;
    void Awake()
    {
        instance = this;
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
            
            
            player.Move(Vector2.left);
            if (player.isFacingRight)
            {
                player.transform.localScale = new Vector2(-1 * player.transform.localScale.x, player.transform.localScale.y);
            }
            
            player.isFacingRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {

            if (!player.isFacingRight)
            {
                player.transform.localScale = new Vector2(-1 * player.transform.localScale.x, player.transform.localScale.y);
            }
            player.Move(Vector2.right);
            player.isFacingRight = true;
        }
        else
        {
            player.animator.SetBool("isWalking", false);


        }
        
    }
    
}
