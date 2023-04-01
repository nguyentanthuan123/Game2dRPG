using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    public AudioSource audioSource;

    public Slider volumeSlider;

    private void Start()
    {
        LoadValues();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
        SetVolume(volumeValue);
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
