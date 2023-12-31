using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanel;
    public static bool hasPressed = false;
    private void Start()
    {
        hasPressed = false;
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
        if (!hasPressed)
        {
            hasPressed = true;
            MainManager.instance.HandleRespawn();
        }
        
       
    }
    public void NewGame()
    {
        if (!hasPressed)
        {
            hasPressed = true;
            DataPersistenceManager.instance.NewGame();
            MainManager.instance.PlayIntroCutscene();
        }

    }
    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }
    public void PlaySelectedSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Select,Vector3.zero);
    }
}
