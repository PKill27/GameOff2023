using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.currentGround = GroundOption.water;
            Player.instance.isInWater = true;
            Player.instance.freezeRate *= 5;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.isInWater = false;
            Player.instance.freezeRate /= 5;
            
        }
    }
}
