using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> paths;
    
    private int pathIndex = 0;
    private bool isMovingForward = true;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        pathIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (paths.Count == 0)
        {
            Debug.LogError("Paths list is empty. Add waypoints to the paths list in the Inspector.");
            return;
        }

        // Get the current target position from the paths list
        Vector2 targetPos = paths[pathIndex].position;

        // Calculate the direction to the target waypoint
        Vector2 moveDirection = (targetPos - (Vector2)transform.position).normalized;

        // Move the enemy in the calculated direction
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Check if the enemy has gone past the waypoint in the moving direction
        float distanceToWaypoint = Vector2.Dot(moveDirection, targetPos - (Vector2)transform.position);
        if (distanceToWaypoint <= 0f)
        {
            // If moving forward, go to the next point in the path
            if (isMovingForward)
            {
                pathIndex++;
                if (pathIndex >= paths.Count)
                {
                    // If reached the end of the path, stop moving
                    pathIndex = paths.Count - 1;
                    isMovingForward = false;
                }
            }
            // If moving backward, go to the previous point in the path
            else
            {
                pathIndex--;
                if (pathIndex < 0)
                {
                    // If reached the beginning of the path, stop moving
                    pathIndex = 0;
                    isMovingForward = true;
                }
            }
        }
    }
}
