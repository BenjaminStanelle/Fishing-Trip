using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstaclesSpawner : MonoBehaviour
{
    public int IsRunning = 1;
    public float timeUntilStage2;
    public float NumberofSeconds;

    public Transform[] spawnPoints;
    public GameObject[] obstaclePrefabs;
    int mud=0, rock=1, bush=2, pickObstacle=0, i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (timeUntilStage2 > 0)
        {
            timeUntilStage2 -= Time.deltaTime;
        }
        else if(IsRunning==1)
        {
            StartCoroutine(Wait());
        }
    }



    public IEnumerator Wait()
    {
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);
        pickObstacle = Random.Range(0, 3); //exclusive max range value, Rarity level of 100%

        if (pickObstacle == mud)
        {
            spawnMud();
        }
        else if (pickObstacle == rock)
        {
            spawnRock();
        }
        else if (pickObstacle == bush)
        {
            spawnBush();
        }
        IsRunning = 1;
    }

    void spawnMud()
    {
        Instantiate(obstaclePrefabs[mud], spawnPoints[0].position, transform.rotation);
    }
    void spawnRock()
    {
        Instantiate(obstaclePrefabs[rock], spawnPoints[0].position, transform.rotation);
    }
    void spawnBush()
    {
        Instantiate(obstaclePrefabs[bush], spawnPoints[0].position, transform.rotation);
    }
}
