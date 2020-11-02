using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator1 : MonoBehaviour
{
    [SerializeField] private Transform groundpart = null; //allow field to be assigned in inspector
    [SerializeField] private Transform groundstart = null;

    private GameObject Player;
    private Vector3 lastEndPosition; //for spawning more ground

    public float Spawn_Distance_To_Player; //for distance to spawn ground from player

    // Awake is called before Start
    private void Awake()
    {
        lastEndPosition = groundstart.Find("EndPosition").position;
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
            SpawnGroundProcess();
        }
    }

    private void SpawnGroundProcess()
    {
        Transform lastgroundpart = SpawnGround(lastEndPosition);
        lastEndPosition = lastgroundpart.Find("EndPosition").position;
    }

    private Transform SpawnGround(Vector3 SpawnPosition)
    {
        Transform GroundEnd = Instantiate(groundpart, SpawnPosition, transform.rotation);
        return GroundEnd;
    }
}
