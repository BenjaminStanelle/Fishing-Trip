using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class MoveObstacle : MonoBehaviour
{
    Camera m_MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < (m_MainCamera.transform.position.x - 33) || this.transform.position.y < (m_MainCamera.transform.position.y - 15))
        {
            Destroy(this.gameObject);
        }

    }


}
