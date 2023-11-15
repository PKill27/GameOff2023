using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public RedPanda player;
    public Camera mainCamera;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
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
