using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    public float followSpeed = 7f; 
    public float followThreshold = 4f;
    public float yOffset = 1;
    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.position);
 
        if (distance > followThreshold)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y+1.2f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
