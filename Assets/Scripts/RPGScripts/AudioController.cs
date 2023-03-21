using UnityEngine.Audio;
using UnityEngine;

public class AudioController: MonoBehaviour
{
    public SoundClip[] sounds;

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
