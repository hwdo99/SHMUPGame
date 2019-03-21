using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    int defaultHighScore = 100;
    public static int highscore0;
    public static int currentScore;
    public static List<int> scores = new List<int>(10);
    Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GetComponent<Text>();
        currentScore = 0;

        if (!PlayerPrefs.HasKey($"High Score0"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score0", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score1"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score1", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score2"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score2", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score3"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score3", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score4"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score4", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score5"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score5", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score6"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score6", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score7"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score7", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score8"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score8", defaultHighScore); // If it’s not, then save one
        }
        if (!PlayerPrefs.HasKey($"High Score9"))
        {
            // Check to see if a high score is already saved
            PlayerPrefs.SetInt($"High Score9", defaultHighScore); // If it’s not, then save one
        }
        highscore0 = PlayerPrefs.GetInt("High Score0"); // Save the high score as a reference
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + currentScore + " / Highscore: " + highscore0;
    }
}
