using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NewGameText : MonoBehaviour
{
    public TextMeshProUGUI message;
    void Start()
    {
        StartCoroutine(TypeSentence("Climb to the Top! good Luck"));
    }

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        yield return new WaitForSeconds(1f);
        foreach (char letter in sentence.ToCharArray())
        {

            message.text += letter;

            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(2f);
        MainManager.instance.HandleRespawn();
       
    }
}
