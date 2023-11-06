using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    public float followSpeed = 5f; 
    public float followThreshold = 2f; 

    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.position);
 
        if (distance > followThreshold)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
