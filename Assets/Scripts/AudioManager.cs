using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonidos : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioSource musicSource;
    public AudioClip introMusic;
    public AudioClip menuMusic;
    public AudioClip effectClick;

    public Slider sliderMusic;
    public Slider sliderSFX;

    public static Sonidos instance;

    void Awake()
    {
        instance = this;
        InitializeVolume();
    }

    private void InitializeVolume()
    {
        effectSource.volume = PlayerPrefs.GetFloat("sfxvolumen", 1.0f);
        musicSource.volume = PlayerPrefs.GetFloat("musicvolumen", 1.0f);

        sliderMusic.value = musicSource.volume;
        sliderSFX.value = effectSource.volume;
    }

    public void PlayEffect()
    {
        effectSource.PlayOneShot(effectClick);
    }

    public void PlaySong(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }

    public void OnMusicVolumeUpdate()
    {
        musicSource.volume = sliderMusic.value;
        PlayerPrefs.SetFloat("musicvolumen", musicSource.volume);
        PlayerPrefs.Save();
    }

    public void OnSFXVolumeUpdate()
    {
        effectSource.volume = sliderSFX.value;
        PlayerPrefs.SetFloat("sfxvolumen", effectSource.volume);
        PlayerPrefs.Save();
    }
}