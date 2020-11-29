using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSave : MonoBehaviour
{

    private Slider VolumeSliderGet;

    public void OnValueChanged(float newVolume)
    {
        PlayerPrefs.SetFloat("volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

    // Start is called before the first frame update
    void Start()
    {
        VolumeSliderGet = GameObject.Find("MusicSkinSlider").GetComponent<Slider>();
        PlayerPrefs.SetFloat("volume", VolumeSliderGet.value);
        PlayerPrefs.Save();
    }
}
