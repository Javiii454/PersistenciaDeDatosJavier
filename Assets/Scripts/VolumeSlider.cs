using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class VolumeSlider : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;

    private Slider volumeSlider;

    [SerializeField] private string volumeParameter;

    [SerializeField] private Toggle muteToggle;

    private bool muted;


    void Awake()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        muteToggle = GetComponentInChildren<Toggle>();

        muteToggle.onValueChanged.AddListener(Mute);
    }

    void Start()
    {
        float volume = PlayerPrefs.GetFloat(volumeParameter, 1);

        audioMixer.SetFloat(volumeParameter, Mathf.Log10(volume) * 20);

        volumeSlider.value = volume;

        string mutedValue = PlayerPrefs.GetString(volumeParameter + "Mute", muted.ToString());

        if (mutedValue == "False")
        {
            muted = false;
        }
        else if (mutedValue == "True")
        {
            muted = true;
        }

        muteToggle.isOn = !muted;

    }

    void Mute(bool soundEnabled)
    {
        if (soundEnabled)
        {
            float lastVolume = PlayerPrefs.GetFloat(volumeParameter, 1f);
            audioMixer.SetFloat(volumeParameter, Mathf.Log10(lastVolume) * 20);
            muted = false;
        }
        else
        {
            PlayerPrefs.SetFloat(volumeParameter, volumeSlider.value);
            audioMixer.SetFloat(volumeParameter, -80);
            muted = true;
        }
    }

    void ChangeVolume(float value)
    {
        audioMixer.SetFloat(volumeParameter, Mathf.Log10(value) * 20);
        muteToggle.isOn = true;
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, volumeSlider.value);

        PlayerPrefs.SetString(volumeParameter + "Mute", muted.ToString());
    }
}
