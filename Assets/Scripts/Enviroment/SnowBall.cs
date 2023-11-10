using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float timeTillDespawn;
    public float timeAlive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeTillDespawn)
        {
            Explode();
        }
    }
    public void Explode()
    {
        //play animation
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.HitProjectile(10);
            Explode();
        }
    }
}
