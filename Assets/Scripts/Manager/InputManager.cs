using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputManager instance;
    public Player player;
    public Camera mainCamera;
    void Awake()
    {
        instance = this;
    }

    
    void Update()
    {
        if (!player.isDashing)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (player.isGrounded)
                {
                    player.Jump();
                }
                else
                {
                    /**Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y));
                    Vector3 directionToMouse = mousePosition - transform.position;
                    directionToMouse.Normalize();
                    player.Dash(directionToMouse);**/

                    player.Dash(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized);
                }
               
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.Move(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.Move(Vector2.right);
        }
        
    }
    
}
