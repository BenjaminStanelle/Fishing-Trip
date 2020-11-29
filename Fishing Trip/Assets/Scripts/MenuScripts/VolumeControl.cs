using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{ 
    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
