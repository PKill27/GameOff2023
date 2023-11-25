using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int checkpoint;
    public int musicVol;
    public int sfxVol;
    public int masterVol;
    public bool[] monologues;
    public GameData()
    {
        this.checkpoint = 0;
        this.musicVol = 100;
        this.sfxVol = 100;
        this.masterVol = 100;
        this.monologues = new bool[10] {false, false, false, false, false, false, false, false, false, false };
        
    }
}
