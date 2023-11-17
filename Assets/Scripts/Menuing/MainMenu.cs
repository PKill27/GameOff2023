using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanel;

    private void Start()
    {
        print(DataPersistenceManager.instance.gameData.checkpoint);
        if (DataPersistenceManager.instance.gameData==null)
        {
            gameObject.SetActive(false);
        }
    }
    public void ContinueGame()
    {
        DataPersistenceManager.instance.LoadGame();
        LoadScene.instance.LoadLevel("Platforming");
    }
    public void NewGame()
    {
        DataPersistenceManager.instance.NewGame();
        LoadScene.instance.LoadLevel("NewGameScene");
    }
    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }
}
