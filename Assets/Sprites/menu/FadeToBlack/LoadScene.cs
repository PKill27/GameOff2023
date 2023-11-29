using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator transition;
    public Animator OptionalTitleName;
    public static LoadScene instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        AudioManager.instance.InitializeMusic(FMODEvents.instance.Music1);
        
        /**if (SceneManager.GetActiveScene().name == "Platforming")
        {
            if(MainManager.instance.mainWorldPos != new Vector2(0, 0))
            {
                Player.instance.transform.position = MainManager.instance.mainWorldPos;
            }
            else
            {
                Player.instance.transform.position = Player.instance.GetCheckPointandPos();
            }
            
        }**/
        {

        }
    }
    public void LoadLevel(string name)
    {
        StartCoroutine(LoadLevelWaiter(name));
        
    }
    IEnumerator LoadLevelWaiter(string name)
    {
        AudioManager.instance.SetParam("Apply Fade Out", 1);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(name);
        yield return new WaitForSeconds(2f);
        if(OptionalTitleName != null)
        {
            OptionalTitleName.SetTrigger("Start");
        }
    }
}
