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


    //player data
    public float temp;
    public float hp;
    public float hunger;
    public Vector2 mainWorldPos;
    public bool isFirstScene = true;
    public bool MainWorldIsFacingRight = true;

    public void LoadData(GameData data)
    {
        this.musicVol = data.musicVol;
        this.sfxVol = data.sfxVol;
        this.checkPoint = data.checkpoint;
        this.monologues = data.monologues;
    }

    public void SaveData(ref GameData data)
    {
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
