using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour
{
    SpriteRenderer render;
    public Sprite[] sprites;
    public float hp;
    public float maxHp;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float dmg)
    {
        hp = hp - dmg;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        else if(hp/maxHp < .2)
        {
            render.sprite = sprites[4];
        }
        else if (hp / maxHp < .4)
        {
            render.sprite = sprites[3];
        }
        else if (hp / maxHp < .6)
        {
            render.sprite = sprites[2];
        }
        else if (hp / maxHp < .8)
        {
            render.sprite = sprites[1];
        }
        else if (hp / maxHp < 1)
        {
            render.sprite = sprites[0];
        }
    }
}
