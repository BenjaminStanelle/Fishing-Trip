using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public int IsRunning = 1;
    public float NumberofSeconds;

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    int bullSpawn = 0, dogSpawn = 1, chickenSpawn = 2;
    int chickenSpawnMin = 2, chickenSpawnMax = 8, chickenSpawnPoint;
    int pickEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(IsRunning == 1)
        {
            StartCoroutine(Wait());
        }

    }
    void spawnBullFun()
    {
        //if (Mathf.RoundToInt(Time.time) % 30 == 1)  
            Instantiate(enemyPrefabs[bullSpawn], spawnPoints[bullSpawn].position, transform.rotation);
        
    }
    void spawnDogFun()
    {
        //if (Mathf.RoundToInt(Time.time) % 30 == 1)  
        Instantiate(enemyPrefabs[dogSpawn], spawnPoints[dogSpawn].position, transform.rotation);
    }

    void spawnChickenFun()
    {
        chickenSpawnPoint=Random.Range(chickenSpawnMin, chickenSpawnMax);
        //if (Mathf.RoundToInt(Time.time) % 30 == 1)  
        Instantiate(enemyPrefabs[chickenSpawn], spawnPoints[chickenSpawnPoint].position, transform.rotation);
    }

    public IEnumerator Wait()
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        pickEnemy = Random.Range(0, 3); //exclusive max range value
        
        if (pickEnemy == 0)
        {
            spawnBullFun();
        }
        else if (pickEnemy == 1)
        {
            spawnDogFun();
        }
        else if (pickEnemy == 2)
        {
            spawnChickenFun();
        }
        IsRunning = 1;
    }
}