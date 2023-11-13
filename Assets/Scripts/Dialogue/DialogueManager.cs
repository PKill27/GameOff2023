using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public List<TextAsset> inkFile;
    public Canvas playerImage;
    public Canvas NPCImage;
    public GameObject customButton;
    public GameObject optionPanel;
    public bool isTalking = false;
    public Animator playerAnim;
    public Animator NPCAnim;
    public GameObject DialogueParent;
    static Story story;
    TextMeshProUGUI nametag;


    public TextMeshProUGUI message;
    List<string> tags;
    static Choice choiceSelected;

    public static DialogueManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public void startDialogue(int Selected)
    {
        story = new Story(inkFile[Selected].text);
        tags = new List<string>();
        choiceSelected = null;
        Player.instance.isTalking = true;
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
            FinishDialogue();
        }
    }
    private void Update()
    {
    }

    private void FinishDialogue()
    {
        DialogueParent.SetActive(false);
        Debug.Log("End of Dialogue!");
    }

    public void ContinueButton()
    {
        Player.instance.isTalking = true;
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
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            
            yield return new WaitForSeconds(.05f);
        }
        yield return null;
    }
    IEnumerator ShowChoices()
    {
        Debug.Log("There are choices need to be made here!");
        List<Choice> _choices = story.currentChoices;
        RectTransform panelRectTransform = optionPanel.GetComponent<RectTransform>();

        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = Instantiate(customButton, optionPanel.transform);
            RectTransform buttonRectTransform = temp.GetComponent<RectTransform>();
            float offsetX = -panelRectTransform.rect.width / 4 + 10f + (buttonRectTransform.rect.width + 10f) * i;
            buttonRectTransform.anchoredPosition = new Vector2(offsetX, 0f);

            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _choices[i].text;
            temp.AddComponent<Selectable>();
            temp.GetComponent<Selectable>().element = _choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
        }

        optionPanel.SetActive(true);

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
            string prefix = t.Split(' ')[0];
            
            string param = t.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "color":
                    SetTextColor(param);
                    break;
                case "speaker":
                    ChangeSpeaker(param);
                    break;
                
            }
        }
    }
   
    private void ChangeSpeaker(string speaker)
    {
      if(speaker == "player")
        {
            playerImage.sortingOrder = 1;
            NPCImage.sortingOrder = 0;
            playerAnim.SetBool("isSelected", true);
            NPCAnim.SetBool("isSelected", false);
        }else if(speaker == "npc")
        {
            playerImage.sortingOrder = 0;
            NPCImage.sortingOrder = 1;
            playerAnim.SetBool("isSelected", false);
            NPCAnim.SetBool("isSelected", true);
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
