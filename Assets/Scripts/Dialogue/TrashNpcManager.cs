using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrashNpcManager : MonoBehaviour
{
    public int[] dialougueList;
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
            if (Player.instance.trashCollected >= 1)
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
            textToTalk.SetActive(false);
            isTalkableTo = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTalkableTo)
        {
            
            dialoguePanel.SetActive(true);
            SpeakerImage.sprite = GetComponent<SpriteRenderer>().sprite;
            DialogueManager.instance.startDialogue(dialogueNumber, SpeakerImage, npcSprite,Player.instance.sprite,0,"Nathalie");
            isTalkableTo = false;
            Player.instance.canPickUpTrash = true;
            if(MainManager.instance.dialogueTracker[0] == 0)
            {
                MainManager.instance.dialogueTracker[0] = 1;
                dialogueNumber = dialougueList[1];
            }
        }
    }

}
