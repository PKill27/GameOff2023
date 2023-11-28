using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MonologueManager : MonoBehaviour
{
    
    public TextMeshProUGUI message;
    public GameObject innerMonoPanel;
    public static MonologueManager instance;
    public bool isMonoLoguing = false;
    public Animator playerTalking;
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
    
    void Update()
    {
        if (!isMonoLoguing)
        {

       
        if (!MainManager.instance.monologues[0] && Player.instance.temp <= 10000)
        {//when player is cold first time
                print("fgetting cold");
            PlayInnerMono("I am very cold better find shelter");
            MainManager.instance.monologues[0] = true;
        }
        else if (!MainManager.instance.monologues[1] && Player.instance.isInFire)
        {
            //by fire first time
            MainManager.instance.monologues[1] = true;
            PlayInnerMono("the fire feels good I am starting to get the feeling back in my body");
        }

        else if (!MainManager.instance.monologues[2] && Player.instance.isInWater)
        {
            //In water first time
            MainManager.instance.monologues[2] = true;
            PlayInnerMono("ohhh the water is so cold if i dont get out fast I might freeze.");
        }

        else if (!MainManager.instance.monologues[3] && Player.instance.hunger <= 20)
        {
            MainManager.instance.monologues[3] = true;
            PlayInnerMono("I am starting to feel hungry better find food soon");
            //hungry first time
        }


            /** if (!seeFoodFirstTime)
             {

             }**/
        }
    }
    public void PlayInnerMono(string message)
    {
        innerMonoPanel.SetActive(true);
        isMonoLoguing = true;
        StartCoroutine(TypeSentence(message));


    }
    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        playerTalking.SetBool("isTalking", true);
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;

            yield return new WaitForSeconds(.03f);
        }
        playerTalking.SetBool("isTalking", false);
        yield return new WaitForSeconds(2f);
        isMonoLoguing = false;
        innerMonoPanel.SetActive(false);
        yield return null;
    }
    
    }
