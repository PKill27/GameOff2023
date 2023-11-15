using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private bool canPickUp;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            canPickUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            Player.instance.trashCollected += 1;
            Destroy(gameObject);
        }
    }
}
