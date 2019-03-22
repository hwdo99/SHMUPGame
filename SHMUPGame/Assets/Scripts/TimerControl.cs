using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{
    float startTime = 60;
    bool startGame;
    float currentTime;
    Text timer;

    public void Start()
    {
        startGame = false;
        currentTime = startTime;
        timer = GetComponent<Text>();
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!startGame)
            {
                startGame = true;
            }
        }

        if (startGame)
        {
            currentTime -= Time.deltaTime;
            timer.text = "Time: " + currentTime;
        }

        if (currentTime <= 0)
        {
            timer.text = "OUT OF TIME";
            SceneManager.LoadScene(2);
        }

    }
}
