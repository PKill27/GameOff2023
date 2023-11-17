using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator transition;
    public static LoadScene instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Platforming")
        {
            if(MainManager.instance.mainWorldPos != new Vector2(0, 0))
            {
                Player.instance.transform.position = MainManager.instance.mainWorldPos;
            }
            else
            {
                Player.instance.transform.position = Player.instance.GetCheckPointandPos();
            }
            
        }
        {

        }
    }
    public void LoadLevel(string name)
    {
        StartCoroutine(LoadLevelWaiter(name));
    }
    IEnumerator LoadLevelWaiter(string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }
}
