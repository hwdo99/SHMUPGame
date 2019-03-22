using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour
{
    public static int startingLives = 3;
    public static int lives;
    Text livesTxt;

    // Start is called before the first frame update
    void Start()
    {
        lives = startingLives;
        livesTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        livesTxt.text = "Lives: " + lives + " / " + startingLives;
        if (lives <= 0)
        {

            if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score0"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", PlayerPrefs.GetInt("High Score7"));
                PlayerPrefs.SetInt("High Score7", PlayerPrefs.GetInt("High Score6"));
                PlayerPrefs.SetInt("High Score6", PlayerPrefs.GetInt("High Score5"));
                PlayerPrefs.SetInt("High Score5", PlayerPrefs.GetInt("High Score4"));
                PlayerPrefs.SetInt("High Score4", PlayerPrefs.GetInt("High Score3"));
                PlayerPrefs.SetInt("High Score3", PlayerPrefs.GetInt("High Score2"));
                PlayerPrefs.SetInt("High Score2", PlayerPrefs.GetInt("High Score1"));
                PlayerPrefs.SetInt("High Score1", PlayerPrefs.GetInt("High Score0"));
                PlayerPrefs.SetInt("High Score0", ScoreScript.currentScore);

            }

            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score1"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", PlayerPrefs.GetInt("High Score7"));
                PlayerPrefs.SetInt("High Score7", PlayerPrefs.GetInt("High Score6"));
                PlayerPrefs.SetInt("High Score6", PlayerPrefs.GetInt("High Score5"));
                PlayerPrefs.SetInt("High Score5", PlayerPrefs.GetInt("High Score4"));
                PlayerPrefs.SetInt("High Score4", PlayerPrefs.GetInt("High Score3"));
                PlayerPrefs.SetInt("High Score3", PlayerPrefs.GetInt("High Score2"));
                PlayerPrefs.SetInt("High Score2", PlayerPrefs.GetInt("High Score1"));
                PlayerPrefs.SetInt("High Score1", ScoreScript.currentScore);
            }

            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score2"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", PlayerPrefs.GetInt("High Score7"));
                PlayerPrefs.SetInt("High Score7", PlayerPrefs.GetInt("High Score6"));
                PlayerPrefs.SetInt("High Score6", PlayerPrefs.GetInt("High Score5"));
                PlayerPrefs.SetInt("High Score5", PlayerPrefs.GetInt("High Score4"));
                PlayerPrefs.SetInt("High Score4", PlayerPrefs.GetInt("High Score3"));
                PlayerPrefs.SetInt("High Score3", PlayerPrefs.GetInt("High Score2"));
                PlayerPrefs.SetInt("High Score2", ScoreScript.currentScore);
            }


            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score3"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", PlayerPrefs.GetInt("High Score7"));
                PlayerPrefs.SetInt("High Score7", PlayerPrefs.GetInt("High Score6"));
                PlayerPrefs.SetInt("High Score6", PlayerPrefs.GetInt("High Score5"));
                PlayerPrefs.SetInt("High Score5", PlayerPrefs.GetInt("High Score4"));
                PlayerPrefs.SetInt("High Score4", PlayerPrefs.GetInt("High Score3"));
                PlayerPrefs.SetInt("High Score3", ScoreScript.currentScore);
            }

            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score4"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", PlayerPrefs.GetInt("High Score7"));
                PlayerPrefs.SetInt("High Score7", PlayerPrefs.GetInt("High Score6"));
                PlayerPrefs.SetInt("High Score6", PlayerPrefs.GetInt("High Score5"));
                PlayerPrefs.SetInt("High Score5", PlayerPrefs.GetInt("High Score4"));
                PlayerPrefs.SetInt("High Score4", ScoreScript.currentScore);
            }

            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score5"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", PlayerPrefs.GetInt("High Score7"));
                PlayerPrefs.SetInt("High Score7", PlayerPrefs.GetInt("High Score6"));
                PlayerPrefs.SetInt("High Score6", PlayerPrefs.GetInt("High Score5"));
                PlayerPrefs.SetInt("High Score5", ScoreScript.currentScore);
            }

            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score6"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", PlayerPrefs.GetInt("High Score7"));
                PlayerPrefs.SetInt("High Score7", PlayerPrefs.GetInt("High Score6"));
                PlayerPrefs.SetInt("High Score6", ScoreScript.currentScore);
            }

            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score7"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", PlayerPrefs.GetInt("High Score7"));
                PlayerPrefs.SetInt("High Score7", ScoreScript.currentScore);
            }

            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score8"))
            {
                PlayerPrefs.SetInt("High Score9", PlayerPrefs.GetInt("High Score8"));
                PlayerPrefs.SetInt("High Score8", ScoreScript.currentScore);
            }

            else if (ScoreScript.currentScore >= PlayerPrefs.GetInt("High Score9"))
            {
                PlayerPrefs.SetInt("High Score9", ScoreScript.currentScore);
            }

            PlayerPrefs.Save();

            EndGameScrene();
        }

    }

    public void EndGameScrene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
