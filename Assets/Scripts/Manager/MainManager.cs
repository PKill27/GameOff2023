using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour, iDataPersistance
{
    public static MainManager instance;
    public int musicVol;
    public int sfxVol;
    public int checkPoint;
    public bool[] monologues;
    public void LoadData(GameData data)
    {
        print("loading");
        this.musicVol = data.musicVol;
        this.sfxVol = data.sfxVol;
        this.checkPoint = data.checkpoint;
        this.monologues = data.monologues;
    }

    public void SaveData(ref GameData data)
    {
        print("savin");
        data.musicVol = this.musicVol;
        data.sfxVol = this.sfxVol;
        data.checkpoint = this.checkPoint;
        data.monologues = this.monologues;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
