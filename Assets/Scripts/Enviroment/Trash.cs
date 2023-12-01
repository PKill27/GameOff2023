using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private bool canPickUp;
    public iInteractablee e;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            e.StartAnimation();
            Player.instance.inRangeOfTrash = true;
            canPickUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            e.EndAnimation();
            canPickUp = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp && MainManager.instance.canPickUpTrash)
        {
            Player.instance.trashCollected += 1;
            Destroy(gameObject);
        }
    }
}
