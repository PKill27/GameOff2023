using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.freezeRate *= 5;
            Player.instance.freezeOverlayMultiplier = 5;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.freezeRate /= 5;
            Player.instance.freezeOverlayMultiplier = 1;
        }
    }
}
