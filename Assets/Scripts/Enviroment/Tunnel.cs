using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tunnel : MonoBehaviour
{
    public string sceneName;
    public bool exitRight;
    public Vector2 posToSendPlayerTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.SaveToMainManager();
            MainManager.instance.playerPosOnLoad = posToSendPlayerTo;
            MainManager.instance.isFacingRightLoadScene = exitRight;
            LoadScene.instance.LoadLevel(sceneName);
        }
        
    }
    
}
