using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    Image image;
    Color baseColor;
    private GameObject pauseMenuPanel;
    [SerializeField]
    private GameObject settingsPanel;
    private void Start()
    {
        pauseMenuPanel = transform.parent.gameObject;
        image = GetComponent<Image>();
        baseColor = image.color;
    }

    public void OnHover()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Highlighted, Vector3.zero);
        image.color = new Color(72f / 255f, 194f / 255f, 254f / 255f, 1f);

    }
    public void HoverExit()
    { 
        image.color = baseColor;
    }
    public void OnResume()
    {
        Player.instance.isPaused = false;
        Player.instance.UnpauseAllAnimations();
        pauseMenuPanel.SetActive(false);
        Player.instance.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        AudioManager.instance.UnPausedGame();
    }
    public void OnQuit()
    {
        LoadScene.instance.LoadLevel("StartScene");
    }
    public void OnSettings()
    {
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void PlaySelectedSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Select, Vector3.zero);
    }
}
