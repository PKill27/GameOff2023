using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{ 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.isInFire = true;
            Player.instance.freezeRate = -Player.instance.freezeRate;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.isInFire = false;
            Player.instance.freezeRate = -Player.instance.freezeRate;
        }
    }
}
