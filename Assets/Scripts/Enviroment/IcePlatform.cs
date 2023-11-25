using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    private bool isPlayerOn;
    public float hp;
    public float maxHp;
    public Sprite damagedSprite;
    public Rigidbody2D rb;
    public Sprite[] sprites;
    private SpriteRenderer render;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (isPlayerOn)
        {
            float hpPercent = hp / maxHp;
            hp = hp - 1;
            if (hp <= 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.gravityScale = 1;
                StartCoroutine(WaitToDestroy());
            }
            else if (hpPercent < .25)
            {
                render.sprite = sprites[2];
            }
            else if (hpPercent < .5)
            {
                render.sprite = sprites[1];
            }
            else if (hpPercent < .75)
            {
                render.sprite = sprites[0];
            } 
        }
    }
    IEnumerator WaitToDestroy()
    {
        for (int i = 3; i < 7; i++)
        {
            render.sprite = sprites[i];
            yield return new WaitForSeconds(.1f);

        }
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = false;
        }
    }
}
