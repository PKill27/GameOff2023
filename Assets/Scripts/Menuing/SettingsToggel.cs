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
            image.sprite = no;
        }
        else
        {
            image.sprite = yes;
        }
    }
}
