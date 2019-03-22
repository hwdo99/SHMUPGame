using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManage : MonoBehaviour
{
    public static AudioSource SFXSource;
    public AudioClip buttonSFX;
    public AudioClip fireSFX;
    public static float SFXvolume;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        SFXSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("SFX"))
        {
            SFXvolume = 0.5f;
            PlayerPrefs.SetFloat("SFX", SFXvolume);
            PlayerPrefs.Save();
        }
        SFXSource.volume = PlayerPrefs.GetFloat("SFX");
    }

    public AudioClip GetButtonSFX()
    {
        SFXSource.clip = buttonSFX;
        return SFXSource.clip;
    }

    public AudioClip GetFireSFX()
    {
        SFXSource.clip = fireSFX;
        return SFXSource.clip;
    }
}
