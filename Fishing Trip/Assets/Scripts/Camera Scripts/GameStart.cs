using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Transform Player5 = null;
    [SerializeField] private Transform BorderLeft = null;
    [SerializeField] private Transform BorderRight = null;

        //Tia Benson
    public Transform field = null;    
    public Camera cam = null;         
    private Transform tempField;

    // Awake is called before Start
    void Awake()
    {
        cam = GetComponent<Camera>();   //TB

        Instantiate(BorderLeft, new Vector3(0, 0, 0), Quaternion.Euler(0,0,90));
        Instantiate(BorderRight, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(Player5, new Vector3(0, 0, 0), transform.rotation);

        //Tia Benson
        Transform Field = Instantiate(field, new Vector3(cam.transform.position.x, cam.transform.position.y, 0), cam.transform.rotation);   
        tempField = Field.transform.parent;
        Field.transform.parent = cam.transform;
        //This stuff creates camera borders, and the player. Player creation will be updated in future.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
