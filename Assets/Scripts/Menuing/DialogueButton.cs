using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    private Image image;
    private Color baseColor;

    private void Start()
    {
        image = GetComponent<Image>();
        baseColor = image.color;
    }

    public void HoverEnter()
    {
      
        //image.color = new Color(72f / 255f, 194f / 255f, 254f / 255f, 1f);

    }
    public void HoverExit()
    {
        //image.color = baseColor;
    }
}
