using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float timeTillDespawn;
    public float timeAlive;
    public Vector2 direction;
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeTillDespawn)
        {
            Explode();
        }
    }

    public void Move()
    {
        rb.velocity = direction;
    }

    public void Explode()
    {
        //play animation
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.Move(Vector2.left*.5f);
        }
        else if(collision.gameObject.CompareTag("Platform"))
        {
            Vector2 collisionNormal = collision.transform.up; 
            Vector2 incomingDirection = (transform.position - collision.transform.position).normalized;
            direction = Vector2.Reflect(incomingDirection, collisionNormal).normalized;
        }
    }
    
}
