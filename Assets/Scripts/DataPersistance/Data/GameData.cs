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
    public int trashCollected;
    public bool[] monologues;
    public int[] dialogueTracker;//each index is a npc the value is the the current dialogue the npc is at
    public int[] trashPiles;
    public GameData()
    {
        this.checkpoint = 0;
        this.musicVol = 100;
        this.sfxVol = 100;
        this.masterVol = 100;
        this.monologues = new bool[10] {false, false, false, false, false, false, false, false, false, false };
        this.dialogueTracker = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0};
        this.trashCollected = 0;
        this.trashPiles = new int[3] { 0, 0, 0 };
    }
}
