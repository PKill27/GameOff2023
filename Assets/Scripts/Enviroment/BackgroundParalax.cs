using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour { 

    public Rigidbody2D player;
    public float backgroundSpeed = 0.5f;
    private float startX;
    Rigidbody2D rb;
    private void Start()
    {
        startX = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocityX = player.velocityX * backgroundSpeed;
 
}
}