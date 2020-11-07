using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator1 : MonoBehaviour
{
    [SerializeField] private GameObject groundpart = null; //allow field to be assigned in inspector
    [SerializeField] private GameObject groundstart = null;

    private GameObject Player, lastgroundpart, GroundEnd, temp;
    private Vector3 lastEndPosition; //for spawning more ground


    public float Spawn_Distance_To_Player; //for distance to spawn ground from player

    // Awake is called before Start
    private void Awake()
    {
        lastEndPosition = groundstart.transform.Find("EndPosition").position;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        if(Vector3.Distance(Player.transform.position, lastEndPosition) < Spawn_Distance_To_Player)
        {
            Destroy(temp);  //destroy previous platform
            SpawnGroundProcess();
        }
    }

    private void SpawnGroundProcess()
    {
        temp = GroundEnd;   //create temporary variable to hold platform

        lastgroundpart = SpawnGround(lastEndPosition);
        lastEndPosition = lastgroundpart.transform.Find("EndPosition").position;
    }

    private GameObject SpawnGround(Vector3 SpawnPosition)
    {
        GroundEnd = Instantiate(groundpart, SpawnPosition, transform.rotation);
        return GroundEnd;
    }
}
