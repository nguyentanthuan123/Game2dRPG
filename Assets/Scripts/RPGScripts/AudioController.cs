using UnityEngine.Audio;
using UnityEngine;

public class AudioController: VolumeSliderController
{
    public SoundClip[] sounds;
    VolumeSliderController setting;
    private void Awake()
    {
        foreach(SoundClip s in sounds)
        {
            s.audioSource = gameObject.GetComponent<AudioSource>();
            s.audioSource.clip = s.clip;

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }
    }
}
