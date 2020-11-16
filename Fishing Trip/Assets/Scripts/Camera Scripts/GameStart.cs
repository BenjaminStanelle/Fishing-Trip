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
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
