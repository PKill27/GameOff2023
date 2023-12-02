using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrashNpcManager : MonoBehaviour
{
    public int[] dialougueList;
    public iInteractablee e;

    // Start is called before the first frame update
    void Start()
    {
        if(MainManager.instance != null)
        {
            dialogueNumber = dialougueList[MainManager.instance.dialogueTracker[0]];
        }
        else
        {
            dialogueNumber = 0;
        }
       
    }
    public int dialogueNumber;
    public GameObject dialoguePanel;
    public GameObject textToTalk;
    private bool isTalkableTo;
    public Image SpeakerImage;
    public Sprite npcSprite;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            e.StartAnimation();
            if (MainManager.instance.trashCollected >= 3)
            {
                MainManager.instance.dialogueTracker[0] = 2;
                dialogueNumber = dialougueList[2];
                Player.instance.canBeSpirit = true;
            }
            textToTalk.SetActive(true);
            isTalkableTo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            e.EndAnimation();
            textToTalk.SetActive(false);
            isTalkableTo = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTalkableTo)
        {
            
            dialoguePanel.SetActive(true);
            e.EndAnimation();
            SpeakerImage.sprite = GetComponent<SpriteRenderer>().sprite;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.TextBoxPopUp, Vector3.zero);
            DialogueManager.instance.startDialogue(dialogueNumber, SpeakerImage, npcSprite,Player.instance.sprite,0,"Nathalie");
            isTalkableTo = false;
            MainManager.instance.canPickUpTrash = true;
            textToTalk.SetActive(false);
            if (MainManager.instance.dialogueTracker[0] == 0)
            {
                MainManager.instance.dialogueTracker[0] = 1;
                dialogueNumber = dialougueList[1];
            }
        }
    }

}
