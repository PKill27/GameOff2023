using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsToggel : MonoBehaviour
{
    public Image image;
    public Sprite yes;
    public Sprite no;
    
    public void OnTogle()
    {
        if(image.sprite == yes)
        {
            Screen.fullScreen = false;
            MainManager.instance.fullScreen = false;
            image.sprite = no;
        }
        else
        {
            Screen.fullScreen = true;
            MainManager.instance.fullScreen = true;
            image.sprite = yes;
        }
    }
    public void PlaySelectedSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Select, Vector3.zero);
    }
    public void PlayBackSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Back, Vector3.zero);
    }
}
