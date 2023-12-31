using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerPanda : MonoBehaviour
{
   
    public RedPanda player;
    public GameObject pausePanel;
    void Awake()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            player.isPaused = true;
            player.PauseAllAnimations();
            pausePanel.SetActive(true);
            player.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            AudioManager.instance.PausedGame();
        }
        else if(!player.isPaused)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (player.canJump&&MainManager.instance.canMove)
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
                player.rb.velocityX = player.rb.velocityX/1.05f;
                player.animator.SetBool("isWalking", false);
                player.isWalking = false;

            }
        }
        
    }
    
}
