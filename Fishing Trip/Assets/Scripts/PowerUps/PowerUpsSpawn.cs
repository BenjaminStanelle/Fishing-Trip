using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawn : MonoBehaviour
{
    public GameObject[] powerUp;
    public Transform[] spawnPoint;
    int randPU;
    int randPos;
    public float startTime;
    public float timeBtSpawn = 5;
    public void Update()
    {
        randPU = Random.Range(0, powerUp.Length);
        randPos = Random.Range(0, spawnPoint.Length);

        if (timeBtSpawn <= 0 )
        {
            Instantiate(powerUp[randPU], spawnPoint[randPos].transform.position, transform.rotation);
            timeBtSpawn = startTime;

        }
        else
        {
            timeBtSpawn -= Time.deltaTime;
        }

    }
    

    
}
