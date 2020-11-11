using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator1 : MonoBehaviour
{
    [SerializeField] private GameObject groundpart = null; //allow variable to be assigned in inspector
    [SerializeField] private GameObject groundstart = null;
    [SerializeField] private GameObject fieldpart = null;
    [SerializeField] private GameObject fieldstart = null;
    [SerializeField] private GameObject forestpart = null;
    [SerializeField] private GameObject beachpart = null;

    private GameObject Player, lastgroundpart, GroundEnd, lastBackgroundpart, BackgroundEnd, Backgroundpart;
    private Vector3 lastGroundEndPosition, lastBackgroundEndPosition; //for holding the end position of the current ground/background
    private int counter=0;


    public float Spawn_Distance_To_Player, BG_Spawn_Distance; //for distance to spawn objects from player

    // Awake is called before Start
    private void Awake()
    {
        Backgroundpart = fieldpart; //sets backgroundpart to start as Field, function will be made to change this variable to other backgrounds later.
        lastGroundEndPosition = groundstart.transform.Find("EndPosition").position;//Find first ground end position
        lastBackgroundpart = fieldstart;//find first background end position
    }

    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");//Find player after it has been created
        InvokeRepeating("ChangeBG", 10f, 10f);// this calls ChangeBG function after 10s then repeats every 10s, temporary solution to BG changes.
        //Don't delete, will be used in LevelGenerator3 to change the backgrounds even once the difficulty is max
    }

    // Update is called once per frame
    private void Update()
    {
        if(GameObject.FindWithTag("Player")== null)
        {
            return;
        }
        if (Vector3.Distance(Player.transform.position, lastGroundEndPosition) < Spawn_Distance_To_Player)
        {
            SpawnGroundProcess();//if distance between player and end of last spawned ground piece is below spawn distance, run SpawnGroundProcess
        }

        if(Vector3.Distance(Player.transform.position, lastBackgroundEndPosition) < BG_Spawn_Distance)
        {
            SpawnBackgroundProcess();//same as above, but for background
        }
    }

    private void SpawnGroundProcess()
    {
        lastgroundpart = SpawnGround(lastGroundEndPosition); // last ground part is the returned location of the newest spawned ground
        lastGroundEndPosition = lastgroundpart.transform.Find("EndPosition").position; //last end position is the location of the EndPosition object from the last ground part
    }

    private GameObject SpawnGround(Vector3 SpawnPosition)
    {
        GroundEnd = Instantiate(groundpart, SpawnPosition, transform.rotation);
        return GroundEnd;
    }

    private void SpawnBackgroundProcess()
    {
        lastBackgroundEndPosition = lastBackgroundpart.transform.Find("EndPosition").position;// do this first so SpawnPosition will be appropriate, since the Backgrounds move
        lastBackgroundpart = SpawnBackground(lastBackgroundEndPosition);
    }

    private GameObject SpawnBackground(Vector3 SpawnPosition)
    {
        BackgroundEnd = Instantiate(Backgroundpart, SpawnPosition, transform.rotation);
        return BackgroundEnd;
    }

    private void ChangeBG()//currently runs every 10 seconds for ease of testing, actual timer can be decided later. Don't delete, will be used in LevelGenerator3
    {
        if (counter==0)
        {
            counter++;
            Backgroundpart = forestpart;
        }
        else if (counter == 1)
        {
            counter++;
            Backgroundpart = beachpart;
        }
        else
        {
            counter = 0;
            Backgroundpart = fieldpart;
        }
    }
}
