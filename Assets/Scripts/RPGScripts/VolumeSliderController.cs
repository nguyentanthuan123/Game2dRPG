using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    [Header("Music")]
    public AudioSource audioSource;
    public Slider volumeSlider;

    private void Start()
    {
        audioSource.volume = 1f;
        LoadValues();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SaveVolumeButton()
    {

        float volumeValue = volumeSlider.value;
        SetVolume(volumeValue);
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
