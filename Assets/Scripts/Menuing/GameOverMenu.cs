using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    private Image image;
    private Color baseColor;
    private void Start()
    {
        image = GetComponent<Image>();
        baseColor = image.color;
    }
    public void OnRespawn()
    {
        /**Player.instance.transform.position = Player.instance.GetCheckPointandPos();
        Player.instance.hunger = 0;
        Player.instance.temp = 0;
        Player.instance.hp = Player.instance.maxHp;
        Player.instance.isGameOver = false;
        Player.instance.hasStartedEndGame = false;
        gameOverPanel.SetActive(false);

        Player.instance.animator.SetBool("isDead", false);**/
        MainManager.instance.HandleRespawn();
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void HoverEnter()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Highlighted, Vector3.zero);
        image.color = new Color(72f / 255f, 194f / 255f, 254f / 255f, 1f);

    }
    public void HoverExit()
    {
        image.color = baseColor;
    }
    public void PlaySelectedSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Select, Vector3.zero);
    }
}
