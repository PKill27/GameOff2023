using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MonologueManager : MonoBehaviour
{
    public bool coldFirstTime = false;
    public bool nextToFireFirstTime = false;
    public bool hungryFirstTime = false;
    public bool inWaterFirstTime = false;
    public bool seeFoodFirstTime = false;
    public TextMeshProUGUI message;
    public GameObject innerMonoPanel;
    public static MonologueManager instance;
    
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
        if (!coldFirstTime)
        {

        } 
        else if (!hungryFirstTime)
        {

        }
        if (!nextToFireFirstTime&&Player.instance.isInFire)
        {
           nextToFireFirstTime = true;
           PlayInnerMono("the fire feels good I am starting to get the feeling back in my body");
        }
        if (!inWaterFirstTime && Player.instance.isInWater)
        {
            inWaterFirstTime = true;
            PlayInnerMono("ohhh the water is so cold if i dont get out fast I might freeze.");
        }
        else if (!seeFoodFirstTime)
        {

        }
    }
    public void PlayInnerMono(string message)
    {
        innerMonoPanel.SetActive(true);
        StartCoroutine(TypeSentence(message));


    }
    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;

            yield return new WaitForSeconds(.05f);
        }
        yield return new WaitForSeconds(4f);
        innerMonoPanel.SetActive(false);
        yield return null;
    }
    
    }
