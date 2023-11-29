using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public int checkPointId;
    public static Fire instance;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.isInFire = true;
            Player.instance.freezeRate = -Player.instance.freezeRate*10;
            if (MainManager.instance.checkPoint < checkPointId)
            {
                MainManager.instance.checkPoint = checkPointId;
            }
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.isInFire = false;
            Player.instance.freezeRate = -Player.instance.freezeRate/10;
        }
    }
}
