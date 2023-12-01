using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool isFacingRightLoadScene = true;
    public Vector2 playerPosOnLoad;
    public bool isRespawn = false;//keeps track if the new load is a respawn or from a tunnel
    public bool playLevelLoader;
    public bool canMove = true;
    public bool canPickUpTrash;
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
            print("heheeh");
            LoadLevelOverworld("Level 1",new Vector2(-22,-3.1f));
            //StartCoroutine(OverworldPos());
        }
        else if(checkPoint == 1)
        {
            //Player.instance.SaveToMainManager();
            LoadLevelRespawn("Cave Start");
            //Player.instance.transform.position = Fire.instance.transform.position;
        }
        else if (checkPoint == 2)
        {
            LoadLevelRespawn("Cave 2");
        }
        else if (checkPoint == 3)
        {
            LoadLevelRespawn("Cave 3");
        }
        else if (checkPoint == 4)
        {
            LoadLevelRespawn("Cave 4");
        }
        StartCoroutine(FalseRespawn());
        
    }
    IEnumerator OverworldPos()
    {

        yield return new WaitForSeconds(2.1f);
        Player.instance.transform.position = new Vector2(-22, -3.1f);
        

    }

    IEnumerator FalseRespawn() {

        yield return new WaitForSeconds(3);
        isRespawn = false;

    }
    
    

    public void HandleRespawnStart() { 
        if (checkPoint == 0)
        {
            Player.instance.transform.position = new Vector2(-22, -3.1f);
        }
        else if (checkPoint == 1)
        {
            
            Player.instance.transform.position = Fire.instance.transform.position;
        }
        else if (checkPoint == 2)
        {
            Player.instance.transform.position = Fire.instance.transform.position;
        }
        else if (checkPoint == 3)
        {
            Player.instance.transform.position = Fire.instance.transform.position;
        }
        else if (checkPoint == 4)
        {
            Player.instance.transform.position = Fire.instance.transform.position;
        }

    }
    public void LoadLevelRespawn(string name)
    {
      
        StartCoroutine(LoadLevelWaiterRespawn(name));

    }
    IEnumerator LoadLevelWaiterRespawn(string name)
    {
        AudioManager.instance.SetParam("Apply Fade Out", 1);
        AudioManager.instance.FadeOut();
        LoadScene.instance.transition.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        AudioManager.instance.CleanUp();
        SceneManager.LoadScene(name);

        yield return new WaitForSeconds(.1f);
        if (IntroCutscene.instance != null)
        {
            IntroCutscene.instance.gameObject.SetActive(false);
        }
        
        MainManager.instance.isRespawn = false;
        Player.instance.hunger = 0;
        MainManager.instance.canMove = true;
        Player.instance.temp = 0;
        Player.instance.hp = Player.instance.maxHp;
        Player.instance.transform.position = Fire.instance.transform.position + new Vector3(-1, 0, 0);
        print("respawn");

        yield return new WaitForSeconds(2f);

        if (LoadScene.instance.OptionalTitleName != null)
        {
            LoadScene.instance.OptionalTitleName.SetTrigger("Start");
        }

    }
    public void LoadLevelOverworld(string name, Vector2 pos)
    {
        print("respawn");
        StartCoroutine(LoadLevelWaiterOverworld(name, pos));

    }
    IEnumerator LoadLevelWaiterOverworld(string name, Vector2 pos)
    {
        AudioManager.instance.SetParam("Apply Fade Out", 1);
        AudioManager.instance.FadeOut();
        LoadScene.instance.transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        AudioManager.instance.CleanUp();
        SceneManager.LoadScene(name);
        yield return new WaitForSeconds(.1f);
        if (IntroCutscene.instance != null)
        {
            IntroCutscene.instance.gameObject.SetActive(false);
        }
        Player.instance.hunger = 0;
        Player.instance.temp = 0;
        Player.instance.hp = Player.instance.maxHp;
        Player.instance.transform.position = pos;
        MainManager.instance.canMove = true;
        MainManager.instance.isRespawn = false;
        yield return new WaitForSeconds(2f);

    }
    public void PlayIntroCutscene()
    {
        StartCoroutine(LoadLevelPlayIntoCutscene());
        
    }
    IEnumerator LoadLevelPlayIntoCutscene()
    {
        AudioManager.instance.SetParam("Apply Fade Out", 1);
        AudioManager.instance.FadeOut();
        LoadScene.instance.transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        playLevelLoader = false;
        canMove = false;
        AudioManager.instance.CleanUp();
        SceneManager.LoadScene("Level 1");
        yield return new WaitForSeconds(.1f);
        IntroCutscene.instance.healthBars.SetActive(false);
        IntroCutscene.instance.gameObject.SetActive(true);
        Player.instance.transform.position = new Vector2(-22, -3.1f);

        MainManager.instance.isRespawn = false;

        yield return new WaitForSeconds(2f);
        IntroCutscene.instance.PlayCutscene();

    }
}
