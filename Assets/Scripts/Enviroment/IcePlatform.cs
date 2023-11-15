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
                //render.sprite = sprites[4];
                StartCoroutine(WaitToDestroy());
            }
            
            /**else if(hpPercent < .2)
            {
                render.sprite = sprites[3];
            }
            else if (hpPercent < .4)
            {
                render.sprite = sprites[2];
            }
            else if (hpPercent < .6)
            {
                render.sprite = sprites[1];
            }
            else if (hpPercent < .8)
            {
                render.sprite = sprites[0];
            } **/
        }
    }
    IEnumerator WaitToDestroy()
    {
        print("destorying");
        yield return new WaitForSeconds(.5f);
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
