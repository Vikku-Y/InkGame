using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume", 0.8f)) * 20);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0.5f)) * 20);
        audioMixer.SetFloat("FXVolume", Mathf.Log10(PlayerPrefs.GetFloat("FXVolume", 0.5f)) * 20);

        gameObject.GetComponentInChildren<AudioSource>().playOnAwake = false;
    }

    public void changeMasterVolume(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }

    public void changeMusicVolume(float sliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
