﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{

    public void StartGame()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.LoadScene(1);
    }

    public void ResumeGame()
    {
        SFXManage.instance.PlayButtonSFX();
        Time.timeScale = 1;
        PauseMenu.gameIsPaused = false;
        SceneManager.UnloadSceneAsync(4);
    }

    public void QuitGame()
    {
        SFXManage.instance.PlayButtonSFX();
        Application.Quit();
    }

    public void RestartGame()
    {
        SFXManage.instance.PlayButtonSFX();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ScoreMenu()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

    public void BackToMainMenu()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.UnloadSceneAsync(3);
    }

    public void BackToPauseMenu()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.UnloadSceneAsync(5);
    }

    public void ToSettingsMenu()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
    }

    public void ControlMenu()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    public void BackToMainMenuFromControls()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.UnloadSceneAsync(6);
    }

    public void BackToMainFromAudio()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.UnloadSceneAsync(7);
    }

    public void ToAudioSettings()
    {
        SFXManage.instance.PlayButtonSFX();
        SceneManager.LoadScene(7, LoadSceneMode.Additive);  
    }
}
