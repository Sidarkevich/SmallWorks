using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundActivator : MonoBehaviour
{
    private AudioSource _source;

    public void OnSoundStateChanged(AudioMixerGroup mixer)
    {
        _source.outputAudioMixerGroup = mixer;
    }

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
}
