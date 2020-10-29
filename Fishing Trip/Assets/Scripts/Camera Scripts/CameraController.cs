using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMove MyPlayer;

    private Vector3 lastPlayerPosition;
    private float camMovement;

    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = FindObjectOfType<PlayerMove>();//set MyPlayer = to movement script attached to player object
        lastPlayerPosition = MyPlayer.transform.position; //update player position
    }

    // Update is called once per frame
    void Update()
    {
        camMovement = MyPlayer.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + camMovement, transform.position.y, transform.position.z);
        // x camera movement
        lastPlayerPosition = MyPlayer.transform.position; //update player position
    }
}
