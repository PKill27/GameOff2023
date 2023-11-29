using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanel;

    private void Start()
    {
        print(DataPersistenceManager.instance.gameData);
        DataPersistenceManager.instance.dataHandler = new FileDataHandler(Application.persistentDataPath, DataPersistenceManager.instance.fileName, DataPersistenceManager.instance.useEncryption);
        DataPersistenceManager.instance.dataPersistenceObjects = DataPersistenceManager.instance.FindAllDataPersistenceObjects();

        DataPersistenceManager.instance.gameData = DataPersistenceManager.instance.dataHandler.Load();

        foreach (iDataPersistance dataPersistenceObj in DataPersistenceManager.instance.dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(DataPersistenceManager.instance.gameData);
        }

        if (DataPersistenceManager.instance.gameData == null)
        {
            gameObject.SetActive(false);
        }
    }
    public void ContinueGame()
    {
        //DataPersistenceManager.instance.LoadGame();
        MainManager.instance.HandleRespawn();
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
