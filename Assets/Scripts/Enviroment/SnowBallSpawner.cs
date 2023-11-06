using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallSpawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    public float currTimeBetweenSpawns;
    public GameObject SnowBall;
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
            SpawnSnowBall();
            currTimeBetweenSpawns = 0;
        }
    }
    private void SpawnSnowBall()
    {
        Instantiate(SnowBall,transform.position,Quaternion.identity);
    }
}
