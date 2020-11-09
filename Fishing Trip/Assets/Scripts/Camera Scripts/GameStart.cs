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
    private Vector2 screenBounds;

    //Tia Benson
    public GameObject field, forest, beach = null; 
    private GameObject Field, Forest, Beach;    //clones of gameObject
    public Camera cam = null;         
    private Transform tempField;
    public float timer = 0.0f;
    private int track = 0;

    // Awake is called before Start
    void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));//find the screenboundaries and save the location
        Instantiate(Border, new Vector3(screenBounds.x * -1, 0, 0), Quaternion.Euler(0,0,90));//place border at left screen bound, rotated 90 degrees Z
        Instantiate(Border, new Vector3(screenBounds.x, 0, 0), Quaternion.Euler(0, 0, 90));//place border at right screen bound, rotated 90 degrees Z
        Instantiate(Player5, new Vector3(0, -3, 0), transform.rotation);//create player, will become more complex when skin settings works
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Leaving this to help me develop changing backgrounds later, Jeremy
    /*void Replace()
    {
        timer += Time.deltaTime;    //keep track of seconds

        //Every 3 minutes...
        if (timer > 180.0f && track == 0)  //change to forest
        {
            Forest = Instantiate(forest, new Vector3(cam.transform.position.x, cam.transform.position.y, 0), cam.transform.rotation);
            Forest.transform.parent = cam.transform;
            Destroy(Field); //delete previous background
            timer = 0.0f;
            track++;
        }


        else if (timer > 180.0f && track == 1) //change to beach
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
    }*/
}
