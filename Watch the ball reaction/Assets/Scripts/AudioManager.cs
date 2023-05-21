using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Toggle _toggle; 
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    private void OnEnable()
    {
        var audioSettings = PlayerPrefs.GetInt("AudioSettings", 1);
        if (audioSettings < 1)
        {
            _toggle.isOn = false;
            ChangeAudioSettings(false);
        }
    }

    public void ChangeAudioSettings(bool isActive)
    {
        _soundSource.enabled = isActive;
        _musicSource.enabled = isActive;

        PlayerPrefs.SetInt("AudioSettings", isActive ? 1 : 0);
    }
}
