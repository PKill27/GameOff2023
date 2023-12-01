using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clouds : MonoBehaviour
{
    public Image image; 
    public float speed = 1.5f; 
    void Start()
    {
        if (image == null)
        {
            
            image = GetComponent<Image>();
            float randomNumber = Random.Range(1f, 10f);
            speed = speed * randomNumber;
            if (image == null)
            {
                Debug.LogError("Image component not found. Please assign the Image component in the Inspector or attach it to the same GameObject.");
                enabled = false;
            }
        }
    }
    void Update()
    {
        
        float moveAmount = speed * Time.deltaTime;
        Vector3 newPosition = image.rectTransform.anchoredPosition + new Vector2(moveAmount, 0f);
        image.rectTransform.anchoredPosition = newPosition;

        
        if (newPosition.x > Screen.width)
        {
            newPosition.x = -Screen.width;
            image.rectTransform.anchoredPosition = newPosition;
        }
    }
}
