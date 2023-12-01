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
    
    }
    
    void Update()
    {
        if (!isMonoLoguing)
        {
        if (!MainManager.instance.monologues[0] && Player.instance.temp/Player.instance.freezeTemp >= .15)
        {//when player is cold first time
                
            PlayInnerMono("Need to warm up... ");
            MainManager.instance.monologues[0] = true;
        }
        else if (!MainManager.instance.monologues[1] && Player.instance.isInFire)
        {
            //by fire first time
            MainManager.instance.monologues[1] = true;
            PlayInnerMono("the fire feels good, I am starting to get the feeling back in my body...");
        }

        else if (!MainManager.instance.monologues[2] && Player.instance.isInWater)
        {
            //In water first time
            MainManager.instance.monologues[2] = true;
            PlayInnerMono("This water is freezing…");
        }

        else if (!MainManager.instance.monologues[3] && Player.instance.hunger / Player.instance.maxHunger >= .1)
        {
            MainManager.instance.monologues[3] = true;
            PlayInnerMono("I should find something to eat...");
           
        }
            else if (!MainManager.instance.monologues[4] && Player.instance.inRangeOfTrash)
            {
                MainManager.instance.monologues[4] = true;
                PlayInnerMono("This is probably the trash that Nathalie  wanted me to pick up...");
               
            }
            else if (!MainManager.instance.monologues[5] && Player.instance.trashCollected >=3)
            {
                MainManager.instance.monologues[5] = true;
                PlayInnerMono("Well that is 3 peices of trash, better go back...");
               
            } 
        }
    }
    public void PlayInnerMono(string message)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.TextBoxPopUp, Vector3.zero);
        innerMonoPanel.SetActive(true);
        isMonoLoguing = true;
        StartCoroutine(TypeSentence(message));


    }
    IEnumerator TypeSentence(string sentence)
    {
        AudioManager.instance.InitializeDialogue(FMODEvents.instance.Player);
        message.text = "";
        playerTalking.SetBool("IsTalking", true);
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;

            yield return new WaitForSeconds(.03f);
        }
        playerTalking.SetBool("IsTalking", false);
        AudioManager.instance.StopDialogue();
        yield return new WaitForSeconds(2f);
        isMonoLoguing = false;
        innerMonoPanel.SetActive(false);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.TextBoxPopDisapear, Vector3.zero);
        yield return null;
    }
    
    }
