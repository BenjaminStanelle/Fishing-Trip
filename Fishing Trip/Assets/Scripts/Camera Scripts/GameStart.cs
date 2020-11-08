using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Transform Player1 = null;
    [SerializeField] private Transform Player2 = null;
    [SerializeField] private Transform Player3 = null;
    [SerializeField] private Transform Player4 = null;
    [SerializeField] private Transform Player5 = null;
    [SerializeField] private Transform Border = null;

        //Tia Benson
    public GameObject field, forest, beach = null; 
    private GameObject Field, Forest, Beach;    //clones of gameObject
    public Camera cam = null;         
    private Transform tempField;
    public float timer = 0.0f;
    private int track = 0;

    //Jeremy
    private Vector2 screenBounds;
    private Rigidbody2D rb;

    // Awake is called before Start
    void Awake()
    {
        // Jeremy : This stuff creates camera borders, and the player. Player creation will be updated in future.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));//find screen bounds
        Instantiate(Border, new Vector3(screenBounds.x*-1, 0, 0), Quaternion.Euler(0,0,90));//left border
        Instantiate(Border, new Vector3(screenBounds.x, 0, 0), Quaternion.Euler(0, 0, 90));//right border
        Instantiate(Player1, new Vector3(0, -3, 0), transform.rotation);//player, will become if statement once skin menu finished

        cam = GetComponent<Camera>();   //TB
        //Tia Benson, start with field background
        Field = Instantiate(field, new Vector3(cam.transform.position.x, cam.transform.position.y, 0), cam.transform.rotation);   
        tempField = Field.transform.parent;
        Field.transform.parent = cam.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    //Tia Benson
    void Update()
    {
        timer += Time.deltaTime;    //keep track of seconds

        //Every 3 minutes...
        if(timer > 180.0f && track == 0)  //change to forest
        {
            Forest = Instantiate(forest, new Vector3(cam.transform.position.x, cam.transform.position.y, 0), cam.transform.rotation);
            Forest.transform.parent = cam.transform;   
            Destroy(Field); //delete previous background
            timer = 0.0f;
            track++;
        }


        else if(timer > 180.0f && track == 1) //change to beach
        {
            Beach = Instantiate(beach, new Vector3(cam.transform.position.x, cam.transform.position.y, 0), cam.transform.rotation);
            Beach.transform.parent = cam.transform;   
            Destroy(Forest);
            timer = 0.0f;
            track++;
        }

        else if (timer > 180.0f && track == 2)       //change back to field
        {
            Field = Instantiate(field, new Vector3(cam.transform.position.x, cam.transform.position.y, 0), cam.transform.rotation);
            Field.transform.parent = cam.transform;   
            Destroy(Beach);
            timer = 0.0f;
            track = 0;
        }

        
    }
}
