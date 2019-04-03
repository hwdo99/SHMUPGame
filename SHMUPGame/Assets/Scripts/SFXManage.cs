using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SFXManage : MonoBehaviour
{
    public static SFXManage instance;
    public static AudioSource SFXSource;
    public AudioClip buttonSFX;
    public AudioClip fireSFX;
    public AudioClip explosionSFX;
    public AudioClip destroyEnemySFX;
    public AudioClip getPowerUpSFX;
    public AudioClip PowerUpShotSFX;
    public AudioClip BossHitSFX;
    public AudioClip BossDestroyedSFX;
    public static float SFXvolume;

    private void Awake()
    {
        // makes sure theres only 1 copy
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }

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

    public void PlayButtonSFX()
    {
        SFXSource.PlayOneShot(buttonSFX);
    }

    public void PlayFireSFX()
    {
        SFXSource.PlayOneShot(fireSFX);
    }

    public void PlayExplosionSFX()
    {
        SFXSource.PlayOneShot(explosionSFX);
    }

    public void PlayDestroyEnemySFX()
    {
        SFXSource.PlayOneShot(destroyEnemySFX);
    }

    public void PlayGetPowerUpSFX()
    {
        SFXSource.PlayOneShot(getPowerUpSFX);
    }

    public void PlayPowerUpShotSFX()
    {
        SFXSource.PlayOneShot(PowerUpShotSFX);
    }

    public void PlayBossHitSFX()
    {
        SFXSource.PlayOneShot(BossHitSFX);
    }

    public void PlayBossDestroyedSFX()
    {
        SFXSource.PlayOneShot(BossDestroyedSFX);
    }
}
