using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator1 : MonoBehaviour
{
    [SerializeField] private GameObject groundpart = null; //allow field to be assigned in inspector
    [SerializeField] private GameObject groundstart = null;

    private GameObject Player, lastgroundpart, GroundEnd;
    private Vector3 lastEndPosition; //for spawning more ground


    public float Spawn_Distance_To_Player; //for distance to spawn ground from player

    // Awake is called before Start
    private void Awake()
    {
        lastEndPosition = groundstart.transform.Find("EndPosition").position;//Find first end position
    }

    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");//Find player after it has been created
    }

    // Update is called once per frame
    private void Update()
    {
        if(Vector3.Distance(Player.transform.position, lastEndPosition) < Spawn_Distance_To_Player)
        {
            SpawnGroundProcess();//if far from player, run SpawnGroundProcess
        }
    }

    private void SpawnGroundProcess()
    {
        lastgroundpart = SpawnGround(lastEndPosition); // last ground part is the returned location of the newest spawned ground
        lastEndPosition = lastgroundpart.transform.Find("EndPosition").position; //last end position is the location of the EndPosition object from the last ground part
    }

    private GameObject SpawnGround(Vector3 SpawnPosition)
    {
        GroundEnd = Instantiate(groundpart, SpawnPosition, transform.rotation);
        return GroundEnd;
    }
}
