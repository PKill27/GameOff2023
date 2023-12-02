using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private bool canPickUp;
    public iInteractablee e;
    public int trashId;
    private void Start()
    {
        if (MainManager.instance.trashPiles[trashId] == 1)
        {
            gameObject.SetActive(false);
        }
    }
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
            MainManager.instance.trashPiles[trashId] = 1;
            MainManager.instance.trashCollected += 1;
            Destroy(gameObject);
        }
    }
}
