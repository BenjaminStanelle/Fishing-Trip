using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Transform Player5 = null;
    [SerializeField] private Transform BorderLeft = null;
    [SerializeField] private Transform BorderRight = null;
    // Awake is called before Start
    void Awake()
    {
        Instantiate(BorderLeft, new Vector3(0, 0, 0), Quaternion.Euler(0,0,90));
        Instantiate(BorderRight, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(Player5, new Vector3(0, 0, 0), transform.rotation);
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
