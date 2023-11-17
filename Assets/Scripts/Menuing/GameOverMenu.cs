using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void OnRespawn()
    {
        Player.instance.transform.position = Player.instance.GetCheckPointandPos();
        Player.instance.hunger = 0;
        Player.instance.temp = 0;
        Player.instance.hp = Player.instance.maxHp;
        Player.instance.isGameOver = false;
        Player.instance.hasStartedEndGame = false;
        gameOverPanel.SetActive(false);

        Player.instance.animator.SetBool("isDead", false);
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
