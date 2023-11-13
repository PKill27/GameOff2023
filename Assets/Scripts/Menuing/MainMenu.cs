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
        SceneManager.LoadScene("Platforming");
    }
    public void NewGame()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene("Platforming");
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
