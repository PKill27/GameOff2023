using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaveTransparent : MonoBehaviour
{
    public LayerMask gridLayer;
    public float raycastDistance = 1f;
    public float transparencyValue = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("here");
        if (collision.gameObject.CompareTag("Player"))
        {
            print("here");
            SetTransparency(gameObject, transparencyValue);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetTransparency();
        }
    }

    
    private void SetTransparency(GameObject obj, float alpha)
    {
        Tilemap tilemap = obj.GetComponent<Tilemap>();

        // Check if the object has a Renderer component
        if (tilemap != null)
        {
            StartCoroutine(ChangeTransparency(tilemap,alpha));
            
        }
    }
    IEnumerator ChangeTransparency(Tilemap tilemap,float alpha)
    {
        Color color = tilemap.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;

        while (elapsedTime < 1.5f)
        {
            color.a = Mathf.Lerp(startAlpha, alpha, elapsedTime / 1.5f);
            tilemap.color = color;

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final alpha value is set
        color.a = alpha;
        tilemap.color = color;



    }

    private void ResetTransparency()
    {
        // Reset transparency for all grid objects
        //GameObject[] gridObjects = GameObject.FindGameObjectsWithTag("GridObject");

        SetTransparency(gameObject, 1f);
        /*foreach (GameObject obj in gridObjects)
        {
            SetTransparency(obj, 1f);
        }*/
    }
}