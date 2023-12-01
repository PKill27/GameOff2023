using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbitionSpirit : MonoBehaviour
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
    public Image SpeakerImage;
    public Sprite npcSprite;
    public iInteractablee e;
    public Animator acending;
    public static AmbitionSpirit instance;

    private void Awake()
    {
        instance = this;
    }
    public void acsend()
    {
        acending.SetTrigger("Start");
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            e.StartAnimation();
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
            //SpeakerImage.sprite = GetComponent<SpriteRenderer>().sprite;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.TextBoxPopUp, Vector3.zero);
            DialogueManager.instance.startDialogue(dialogueNumber, SpeakerImage, npcSprite, Player.instance.sprite, 1,"Ambition Spirit");
            isTalkableTo = false;
            textToTalk.SetActive(false);
        }
    }
}
