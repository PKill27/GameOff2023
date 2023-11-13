using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public int checkPointId;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(MainManager.instance.checkPoint < checkPointId)
            {
                MainManager.instance.checkPoint = checkPointId;
            }
        }
    }
}
