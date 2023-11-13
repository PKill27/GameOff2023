using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int checkpoint;
    public int musicVol;
    public int sfxVol;
    public GameData()
    {
        this.checkpoint = 0;
        this.musicVol = 100;
        this.sfxVol = 100;
    }
}
