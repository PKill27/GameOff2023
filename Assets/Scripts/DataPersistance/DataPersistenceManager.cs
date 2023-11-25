using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] public string fileName;
    [SerializeField] public bool useEncryption;

    public GameData gameData;
    public List<iDataPersistance> dataPersistenceObjects;
    public FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
            //Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
      
    }

    private void Start()
    {

        
        
        /**foreach (iDataPersistance dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }**/
        
        
    }

    public void NewGame()
    {
        print("starting new");
        this.gameData = new GameData();
        foreach (iDataPersistance dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void LoadGame()
    {
        
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            //NewGame();
        }

        // push the loaded data to all other scripts that need it
        foreach (iDataPersistance dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        print("savin");
        // pass the data to other scripts so they can update it
        foreach (iDataPersistance dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        // save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public List<iDataPersistance> FindAllDataPersistenceObjects()
    {
        IEnumerable<iDataPersistance> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<iDataPersistance>();

        return new List<iDataPersistance>(dataPersistenceObjects);
    }
}