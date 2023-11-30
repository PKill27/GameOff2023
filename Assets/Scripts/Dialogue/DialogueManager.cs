using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    public List<TextAsset> inkFile;
    public Image speakerImage;
    public GameObject customButton;
    public GameObject optionPanel;
    public bool isTalking = false;
    public GameObject DialogueParent;
    static Story story;
    TextMeshProUGUI nametag;
    public TextMeshProUGUI message;
    List<string> tags;
    static Choice choiceSelected;
    public static DialogueManager instance;

    public Sprite npcImage;
    public Sprite playerImage;

    public GameObject playerGameObject;
    public Animator playerAnimation;

    public GameObject[] npcGameObjects;
    public Animator[] npcAnimations;

    public GameObject npcGameObject;
    public Animator npcAnimation;

    public Animator currSpeaker;

    public TextMeshProUGUI speakerName;
    public bool isShortenedOption;
    private string speaker;
    private List<string> shortendChoices;
    public GameObject continueButton;
    private string prevMessage;
    private int waitTime;
    private bool isTyping;
    private bool continuePressed;
    private string npcName;
    private bool areChoicess;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public void startDialogue(int Selected, Image currentSpeaker,  Sprite npcImage, Sprite playerImage, int indexOfNpc, string npcName)
    {
        shortendChoices = new List<string>();
        story = new Story(inkFile[Selected].text);
        tags = new List<string>();
        choiceSelected = null;
        this.playerImage = playerImage;
        this.npcImage = npcImage;
        Player.instance.isTalking = true;
        speakerImage = currentSpeaker;
        npcGameObject = npcGameObjects[indexOfNpc];
        npcAnimation = npcAnimations[indexOfNpc];
        this.npcName = npcName;
        areChoicess = false;
        if (story.canContinue)
        {
            AdvanceDialogue();
            if (story.currentChoices.Count != 0)
            {
                StartCoroutine(ShowChoices());
            }
        }
        else
        {
            Player.instance.isTalking = false;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.TextBoxPopDisapear, Vector3.zero);
            FinishDialogue();
        }
    }
    private void Update()
    {
        if (Player.instance.isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space)&&!areChoicess)
            {
                ContinueButton();
            }
        }

        
    }

    private void FinishDialogue()
    {
        DialogueParent.SetActive(false);
        Debug.Log("End of Dialogue!");
    }

    public void ContinueButton()
    {
        Player.instance.isTalking = true;
        if (isTyping)
        {
            AudioManager.instance.StopDialogue();
            message.text = prevMessage;
            isTyping = false;
            continuePressed = true;
        }else if (waitTime != 0)
        {

        }

        else if (story.canContinue)
        {
           
                AdvanceDialogue();

                if (story.currentChoices.Count != 0)
                {
                    areChoicess = true;
                    continueButton.SetActive(false);
                    StartCoroutine(ShowChoices());
                }
                else
                {

                }
        }
        else
        {
            Player.instance.isTalking = false;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.TextBoxPopDisapear, Vector3.zero);
            FinishDialogue();
        }
    }

    void AdvanceDialogue()
    {
        string currentSentence = story.Continue();
        ParseTags();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        AudioManager.instance.StopDialogue();
        if (sentence != "")
        {
            prevMessage = sentence;
        }

        if (waitTime != 0)
        {
            print("waiting");
            yield return new WaitForSeconds(waitTime);
            waitTime = 0;
        }
        if (story.currentChoices.Count == 0)
        {
            isTyping = true;
            ChangeSpeaker(speaker);
            if(speakerName.text == "player")
            {
                AudioManager.instance.InitializeDialogue(FMODEvents.instance.Player);
            }else if(speakerName.text == "Nathalie")
            {
                AudioManager.instance.InitializeDialogue(FMODEvents.instance.Nathalie);

            }
            else if(speakerName.text == "Ambition Spirit")
            {
                AudioManager.instance.InitializeDialogue(FMODEvents.instance.Ambition);

            }
            currSpeaker.SetBool("IsTalking", true);
            message.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
               
                if (continuePressed)
                {
                    continuePressed = false;
                    AudioManager.instance.StopDialogue();
                    break;//want the for loop to end here
                }
                else
                {
                    message.text += letter;
                    yield return new WaitForSeconds(.02f);
                }
                
            }
            AudioManager.instance.StopDialogue();
            currSpeaker.SetBool("IsTalking", false);
            isTyping = false;
            yield return null;
        }
        
    }
    IEnumerator ShowChoices()
    {
        Debug.Log("There are choices need to be made here!");
        List<Choice> _choices = story.currentChoices;
        currSpeaker.SetBool("IsTalking", false);
        message.text = prevMessage;
        areChoicess = true;
        RectTransform panelRectTransform = optionPanel.GetComponent<RectTransform>();
        if (isShortenedOption)
        {

        }
        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = Instantiate(customButton, optionPanel.transform);
            RectTransform buttonRectTransform = temp.GetComponent<RectTransform>();
            //float offsetX = -panelRectTransform.rect.width / 4 + 10f + (buttonRectTransform.rect.width + 10f) * i;
            buttonRectTransform.anchoredPosition = new Vector2(200f, 60f * i - 60f);

            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = shortendChoices[i];
            temp.AddComponent<Selectable>();
            temp.GetComponent<Selectable>().element = _choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
        }

        optionPanel.SetActive(true);
        shortendChoices = new List<string>();
        yield return new WaitUntil(() => { return choiceSelected != null; });
        
        AdvanceFromDecision();
    }

    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        story.ChooseChoiceIndex(choiceSelected.index);
    }

    void AdvanceFromDecision()
    {
        optionPanel.SetActive(false);
        areChoicess = false;
        continueButton.SetActive(true);
        for (int i = 0; i < optionPanel.transform.childCount; i++)
        {
            Destroy(optionPanel.transform.GetChild(i).gameObject);
        }
        choiceSelected = null; 
        AdvanceDialogue();
    }
    
    void ParseTags()
    {
       
       
        tags = story.currentTags;
        foreach (string t in tags)
        {
            string[] parts = t.Split(' ');
            string prefix = parts[0];
            string[] remainingParts = parts.Skip(1).ToArray();

            string param = string.Join(" ", remainingParts);

            switch (prefix.ToLower())
            {
                case "color":
                    SetTextColor(param);
                    break;
                case "speaker":
                    speaker = param;
                    break;
                case "option":
                    print(param);
                    string[] shortendChoice = param.Split('~');
                    foreach(string shortened in shortendChoice)
                    {
                        shortendChoices.Add(shortened);
                    }
                    
                    isShortenedOption = true;
                    break;
                case "wait":
                    waitTime = int.Parse(param); 
                    break;
            }
            
        }
    }
   
    private void ChangeSpeaker(string speaker)
    {
      if(speaker == "player")
        {
           
            playerGameObject.SetActive(true);
            npcGameObject.SetActive(false);
            currSpeaker = playerAnimation;
            speakerName.text = "player";
            
        }
        else if(speaker == "npc")
        {
            
            playerGameObject.SetActive(false);
            npcGameObject.SetActive(true);
            speakerName.text = npcName;
            currSpeaker = npcAnimation;
            
        }
    }
    void SetTextColor(string _color)
    {
        switch (_color)
        {
            case "red":
                message.color = Color.red;
                break;
            case "blue":
                message.color = Color.cyan;
                break;
            case "green":
                message.color = Color.green;
                break;
            case "white":
                message.color = Color.white;
                break;
            default:
                Debug.Log($"{_color} is not available as a text color");
                break;
        }
    }
}
