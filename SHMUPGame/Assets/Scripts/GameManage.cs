using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public SFXManage SFXManage;
    public AudioClip buttonSound;
    public AudioSource sfx;

    public void Awake()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        buttonSound = SFXManage.getButtonSFX();
        sfx.clip = buttonSound;
    }

    public void StartGame()
    {
        sfx.Play();
        SceneManager.LoadScene(1);
    }

    public void ResumeGame()
    {
        sfx.Play();
        Time.timeScale = 1;
        //PauseMenu.gameIsPaused = false;
        SceneManager.UnloadSceneAsync(4);
    }

    public void QuitGame()
    {
        sfx.Play();
        Application.Quit();
    }

    public void RestartGame()
    {
        sfx.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ScoreMenu()
    {
        sfx.Play();
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

    public void BackToMainMenu()
    {
        sfx.Play();
        SceneManager.UnloadSceneAsync(3);
    }

    public void BackToPauseMenu()
    {
        sfx.Play();
        SceneManager.UnloadSceneAsync(5);
    }

    public void ToOptionsMenu()
    {
        sfx.Play();
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
    }
}
