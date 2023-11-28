using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour { 

    public Rigidbody2D player;
    public float backgroundSpeedHoriz = 0.5f;
    public float backgroundSpeedVert = 0.5f;
    private float startX;
    Rigidbody2D rb;
    private void Start()
    {
        startX = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position = new Vector2(player.position.x * backgroundSpeedHoriz, player.position.y * backgroundSpeedVert);
}
}