using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    public int IsRunning = 1;
    public float NumberofSeconds;

    public Transform[] spawnPoints;
    public GameObject[] powerUpPrefabs;
    int coffeeSpawn = 3, hookSpawn = 4;
    int pickPowerUp, spawnPoint, pickBait;

    // Update is called once per frame
    void Update()
    {

        if (IsRunning == 1)
        {
            StartCoroutine(Wait());
        }

    }
    void spawnBaitFun()
    {
        spawnPoint = Random.Range(0, spawnPoints.Length);
        pickBait = Random.Range(0, 3);
        Instantiate(powerUpPrefabs[pickBait], spawnPoints[spawnPoint].position, transform.rotation);

    }
    void spawnCoffeeFun()
    {
        spawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(powerUpPrefabs[coffeeSpawn], spawnPoints[spawnPoint].position, transform.rotation);
    }

    void spawnHookFun()
    {
        spawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(powerUpPrefabs[hookSpawn], spawnPoints[spawnPoint].position, transform.rotation);
    }

    public IEnumerator Wait()
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        pickPowerUp = Random.Range(0, 101); //exclusive max range value, Rarity level of 100%

        if (pickPowerUp <=50)
        {
            spawnBaitFun();
        }
        else if (pickPowerUp > 50 && pickPowerUp <=85)
        {
            spawnCoffeeFun();
        }
        else if (pickPowerUp > 85 && pickPowerUp <= 100)
        {
            spawnHookFun();
        }
        IsRunning = 1;
    }
}