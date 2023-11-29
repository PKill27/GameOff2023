using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour, iDataPersistance
{
    public static MainManager instance;
    public int musicVol = 100;
    public int sfxVol = 100;
    public int masterVol = 100;
    public int checkPoint;
    public bool[] monologues;
    public int[] dialogueTracker;

    //player data
    public float temp;
    public float hp;
    public float hunger;
    public Vector2 mainWorldPos;
    public bool isFirstScene = true;
    public bool MainWorldIsFacingRight = true;
    public Vector2 playerPosOnLoad;
    public bool isRespawn = false;//keeps track if the new load is a respawn or from a tunnel

    public void LoadData(GameData data)
    {
        
        if(data == null)
        {
            
            this.musicVol = 100;
            this.sfxVol = 100;
            this.masterVol = 100;
        }
        else
        {
            this.musicVol = data.musicVol;
            this.sfxVol = data.sfxVol;
            this.masterVol = data.masterVol;
            this.checkPoint = data.checkpoint;
            this.monologues = data.monologues;
            this.dialogueTracker = data.dialogueTracker;
        }

        
    }

    public void SaveData(ref GameData data)
    {
        data.musicVol = this.musicVol;
        data.sfxVol = this.sfxVol;
        data.masterVol = this.masterVol;
        data.checkpoint = this.checkPoint;
        data.monologues = this.monologues;
        data.dialogueTracker = this.dialogueTracker;
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
    public void HandleRespawn()
    {
        print(isRespawn);
        isRespawn = true;
        
        if(checkPoint == 0)
        {
            LoadScene.instance.LoadLevelOverworld("Level 1",new Vector2(-20,-1.1f));
        }else if(checkPoint == 1)
        {
            //Player.instance.SaveToMainManager();
            LoadScene.instance.LoadLevelRespawn("Cave Start");
            //Player.instance.transform.position = Fire.instance.transform.position;
        }
        else if (checkPoint == 2)
        {

        }
        else if (checkPoint == 3)
        {

        }
        else if (checkPoint == 4)
        {

        }
        StartCoroutine(FalseRespawn());

    }
    IEnumerator FalseRespawn() {

        yield return new WaitForSeconds(3);
        isRespawn = false;
        print("here");

    }
    
    

            public void HandleRespawnStart() { 
        if (checkPoint == 0)
        {
            Player.instance.transform.position = new Vector2(-20, -1.1f);
        }
        else if (checkPoint == 1)
        {
            
            Player.instance.transform.position = Fire.instance.transform.position;
        }
        else if (checkPoint == 2)
        {

        }
        else if (checkPoint == 3)
        {

        }
        else if (checkPoint == 4)
        {

        }

    }
}
