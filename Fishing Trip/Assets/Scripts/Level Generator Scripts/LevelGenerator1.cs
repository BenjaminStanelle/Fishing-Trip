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
    private PlayerMove PlayerSpeed;
    private Coffee_Mud DeltaSpeed;
    private MoveDog DogSpeed;
    private enemySpawner Spawner;

    public float DifficultyIncreaseTimer = 10;
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
        PlayerSpeed = FindObjectOfType<PlayerMove>();
        DeltaSpeed = FindObjectOfType<Coffee_Mud>();
        Spawner= FindObjectOfType<enemySpawner>();
        InvokeRepeating("DifficultyUp", DifficultyIncreaseTimer, DifficultyIncreaseTimer);// this calls DifficultyUp function after X seconds then repeats every X seconds
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

    private void DifficultyUp()
    {
        switch (counter)//Change Backgrounds
        {
            case 0:
                counter++;
                Backgroundpart = forestpart;
                break;
            case 1:
                counter++;
                Backgroundpart = beachpart;
                break;
            case 2:
                counter = 0;
                Backgroundpart = fieldpart;
                break;
        }
        // adjust player speed
        PlayerSpeed.BaseSpeed += 5f;
        PlayerSpeed.AlterSpeed += 2.5f;
        DeltaSpeed.BaseChange = 5f;
        DeltaSpeed.AlterChange = 2.5f;
        if ((DogSpeed = FindObjectOfType<MoveDog>()) != null)
        {
            DogSpeed.speed += 10f;
        }

        if (Spawner.NumberofSeconds > 1.5f)
        {
            Spawner.NumberofSeconds -= .2f;//increase spawn speed
        }
    }
}
