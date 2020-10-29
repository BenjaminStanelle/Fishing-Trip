using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if(transform.position.x > screenBounds.x)
        {
            transform.position = new Vector3(screenBounds.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > screenBounds.y)
        {
            transform.position = new Vector3(transform.position.x, screenBounds.y, transform.position.z);
        }
    }
}
