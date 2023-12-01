using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    //public Sprite noBerriesimage;
    //private SpriteRenderer render;
    public bool isEatable;
    public iInteractablee e;
    // Start is called before the first frame update
    void Start()
    {
        //render = GetComponent<SpriteRenderer>();
        isEatable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEatable)
        {
            //render.sprite = noBerriesimage;
            Player.instance.Eat();
            StartCoroutine(EatFood());
            
        }
    }
    private IEnumerator EatFood()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            e.StartAnimation();
            isEatable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            e.EndAnimation();
            isEatable = false;
        }
    }
}
