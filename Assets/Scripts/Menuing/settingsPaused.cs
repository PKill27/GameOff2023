using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsPaused : MonoBehaviour
{
    public GameObject pausePanel;
    
    public void CloseSettings()
    {
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(true);
        pausePanel.SetActive(true);
    }

}
