using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField] private Slider volumeSlider = null;
    private Text volumeTextUI = null;

    private void Start()
    {
        LoadValues();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
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
