using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    public float currTimeBetweenSpawns;
    public GameObject Wind;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currTimeBetweenSpawns += Time.deltaTime;
        if (timeBetweenSpawns <= currTimeBetweenSpawns)
        {
            SpawnWind();
            currTimeBetweenSpawns = 0;
        }
    }
    private void SpawnWind() { 

        float randomRotation = Random.Range(-20, 15);
        Quaternion randomQuaternion = Quaternion.Euler(0f, 0f, randomRotation);
        GameObject newWindObject = Instantiate(Wind, transform.position, randomQuaternion);
        Wind wind = newWindObject.GetComponent<Wind>();

        Vector3 forwardDirection = randomQuaternion * Vector3.forward;
        Vector3 rotatedDirection = Quaternion.Euler(0, -90, 0) * forwardDirection;
        Vector2 direction = new Vector2(rotatedDirection.x, rotatedDirection.z);
        direction.Normalize();
        wind.direction = direction;
    }
}
