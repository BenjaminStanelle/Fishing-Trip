using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public int IsRunning = 1;
    public int NumberofSeconds;

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    int bullSpawn = 0;
    int dogSpawn = 1;
    int pick = 0;
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

    public IEnumerator Wait()
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        pick = Random.Range(0, enemyPrefabs.Length);

        if (pick == 0)
        {
            spawnBullFun();
        }
        else if (pick == 1)
        {
            spawnDogFun();
        }
        IsRunning = 1;
    }
}