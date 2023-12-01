using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IntroCutscene : MonoBehaviour
{
    public static IntroCutscene instance;
    public Animator mountainAnimation;
    public Animator textboxAnimator;
    public Animator FadeInAnimator;
    public Animator spiritAnimator;
    public GameObject sky;
    public GameObject Mountain;
    public GameObject fadeIn;
    public TextMeshProUGUI message;

    public Animator playerAnimator;
    public GameObject healthBars;
    public Animator textAnimator;
    private void Awake()
    {
        instance = this;
    }

    public void PlayCutscene()
    {
        StartCoroutine(PlayCutsceneCor());
    }
    IEnumerator PlayCutsceneCor()
    {
        message.text = "";
        string startingMessage = "The mountain calls to you spirit...";
        foreach (char letter in startingMessage.ToCharArray())
        {

            message.text += letter;

            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(1f);
        message.text = "";
        startingMessage = "Reach the top...";
        foreach (char letter in startingMessage.ToCharArray())
        {

            message.text += letter;

            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(1f);
        message.text = "";
        startingMessage = "Fulfill your purpose";
        foreach (char letter in startingMessage.ToCharArray())
        {

            message.text += letter;

            yield return new WaitForSeconds(.1f);
        }
        


        Player.instance.transform.localScale = new Vector2(-1 * Player.instance.transform.localScale.x, Player.instance.transform.localScale.y);

        Player.instance.isFacingRight = true;
        yield return new WaitForSeconds(2f);
        mountainAnimation.SetTrigger("Start");
        yield return new WaitForSeconds(3);
        textboxAnimator.SetTrigger("Start");
        textAnimator.SetTrigger("Start");
        playerAnimator.SetBool("isCutscene", true);
        yield return new WaitForSeconds(1);
        sky.SetActive(false);
        fadeIn.SetActive(true);
        Mountain.SetActive(false);
        textboxAnimator.transform.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        spiritAnimator.SetTrigger("Start");
        FadeInAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        playerAnimator.SetBool("hasFadedIn", true);
        playerAnimator.SetBool("isCutscene", false);
        yield return new WaitForSeconds(1.5f);
        healthBars.SetActive(true);
        MainManager.instance.canMove = true;
        LoadScene.instance.OptionalTitleName.SetTrigger("Start");
        gameObject.SetActive(false);
    }
}
