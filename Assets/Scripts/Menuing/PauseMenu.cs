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
        print("hpverin");
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
    }
    public void OnQuit()
    {
        LoadScene.instance.LoadLevel("StartScene");
    }
    public void OnSettings()
    {
        settingsPanel.SetActive(true);
    }
}
