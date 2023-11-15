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
        dialogueNumber = dialougueList[0];
    }
    public int dialogueNumber;
    public GameObject dialoguePanel;
    public GameObject textToTalk;
    private bool isTalkableTo;
    public Image npcPicture;
    public Image playerPicture;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Player.instance.trashCollected >= 1)
            {
                dialogueNumber = dialougueList[1];
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
            npcPicture.sprite = GetComponent<SpriteRenderer>().sprite;
            playerPicture.sprite = Player.instance.sprite;
            DialogueManager.instance.startDialogue(dialogueNumber);
            isTalkableTo = false;
        }
    }

}
