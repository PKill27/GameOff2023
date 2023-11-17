using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TalkableNPC : MonoBehaviour
{
    public int dialogueNumber;
    public GameObject dialoguePanel;
    public GameObject textToTalk;
    private bool isTalkableTo;
    public Image npcPicture;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
        if (Input.GetKeyDown(KeyCode.E)&& isTalkableTo)
        {
            dialoguePanel.SetActive(true);
            npcPicture.sprite = GetComponent<SpriteRenderer>().sprite;
            //DialogueManager.instance.startDialogue(dialogueNumber, npcPicture);
            isTalkableTo = false;
        }
    }
   
}
