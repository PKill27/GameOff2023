using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tunnel : MonoBehaviour
{
    public string sceneName;
    public bool exitRight;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.SaveToMainManager();
            if (SceneManager.GetActiveScene().name == "Platforming")
            {
                MainManager.instance.MainWorldIsFacingRight = exitRight;
                MainManager.instance.mainWorldPos = Player.instance.transform.position;
            }
            LoadScene.instance.LoadLevel(sceneName);
        }
        
    }
    
}