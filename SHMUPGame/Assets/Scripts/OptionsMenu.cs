using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public SFXManage SFXScript;
    public MusicManage MusicScript;
    AudioSource musicSource;
    AudioSource sfxSource;
    public Slider MusicSlider;
    public Slider SFXslider;

    public void Awake()
    {
        musicSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        sfxSource = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();
        SFXslider.value = PlayerPrefs.GetFloat("SFX");
        MusicSlider.value = PlayerPrefs.GetFloat("Music");
    }
    public void Update()
    {
        sfxSource.volume = SFXManage.SFXvolume;
        musicSource.volume = MusicManage.musicVolume;
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume)
    {
        MusicManage.musicVolume = volume;
        PlayerPrefs.SetFloat("Music", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        SFXManage.SFXvolume = volume;
        PlayerPrefs.SetFloat("SFX", volume);
        PlayerPrefs.Save();
    }
}
