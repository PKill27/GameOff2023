using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour { 

    public Transform player;
    public float backgroundSpeed = 0.5f;
    private float startX;
    private void Start()
    {
        startX = transform.position.x;
    }
    void Update()
    {
        // Calculate the movement distance based on the player's movement
        float moveDistance = player.position.x * backgroundSpeed;

        // Move the background in the opposite direction
        transform.position = new Vector3(startX+moveDistance, transform.position.y, transform.position.z);
    }
}