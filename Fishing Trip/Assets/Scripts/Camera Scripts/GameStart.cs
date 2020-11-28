using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Transform Male1 = null;
    [SerializeField] private Transform Male2 = null;
    [SerializeField] private Transform Female1 = null;
    [SerializeField] private Transform Female2 = null;
    [SerializeField] private Transform Alien = null;
    [SerializeField] private Transform Border = null;
    private Vector2 screenBounds;
    private int skin;

    // Awake is called before Start
    void Awake()
    {
        skin = PlayerPrefs.GetInt("Skin", 0);
        switch (skin)
        {
            case 0:
                Instantiate(Male1, new Vector3(0, -3, 0), transform.rotation);//create player
                break;
            case 1:
                Instantiate(Male2, new Vector3(0, -3, 0), transform.rotation);//create player
                break;
            case 2:
                Instantiate(Female1, new Vector3(0, -3, 0), transform.rotation);//create player
                break;
            case 3:
                Instantiate(Female2, new Vector3(0, -3, 0), transform.rotation);//create player
                break;
            case 4:
                Instantiate(Alien, new Vector3(0, -3, 0), transform.rotation);//create player
                break;
        }
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));//find the screenboundaries and save the location
        Instantiate(Border, new Vector3(screenBounds.x * -1, 0, 0), Quaternion.Euler(0,0,90));//place border at left screen bound, rotated 90 degrees Z
        Instantiate(Border, new Vector3(screenBounds.x, 0, 0), Quaternion.Euler(0, 0, 90));//place border at right screen bound, rotated 90 degrees Z
    }
}
