using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSave : MonoBehaviour
{

    public Slider slider;
    public float sliderValue;
    public void ChangeSldier(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
}
