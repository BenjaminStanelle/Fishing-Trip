using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public int IsRunning = 1;
    public float NumberofSeconds;

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    int bullSpawn = 0, dogSpawn = 1, chickenSpawn = 2, powerUpSpawnMin=3, powerUpSpawnMax = 5, powerUpSpawn=3;
    int pickEnemy = 0, pickPowerUp=3;
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
        //if (Mathf.RoundToInt(Time.time) % 30 == 1)  
        Instantiate(enemyPrefabs[chickenSpawn], spawnPoints[chickenSpawn].position, transform.rotation);
    }

    void spawnPowerUp()
    {
        //if (Mathf.RoundToInt(Time.time) % 30 == 1)  
        pickPowerUp = Random.Range(3, enemyPrefabs.Length);     //actual powerup
        powerUpSpawn= Random.Range(powerUpSpawnMin, spawnPoints.Length);   //position


        Instantiate(enemyPrefabs[pickPowerUp], spawnPoints[powerUpSpawn].position, transform.rotation);

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
        //if statements for different levels to wait for different amount of time
        yield return new WaitForSeconds(Random.Range(1, 5));
        spawnPowerUp();
        IsRunning = 1;
    }
}