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

    public AudioClip getButtonSFX()
    {
        SFXSource.clip = buttonSFX;
        return SFXSource.clip;
    }

    public AudioClip getFireSFX()
    {
        SFXSource.clip = fireSFX;
        return SFXSource.clip;
    }
}
