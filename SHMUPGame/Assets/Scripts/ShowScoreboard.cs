using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreboard : MonoBehaviour
{
    Text Scoreboard;

    // Start is called before the first frame update
    void Awake()
    {
        Scoreboard = GameObject.FindWithTag("Scoreboard").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Scoreboard.text = $"#1 HIGHSCORE: {PlayerPrefs.GetInt("High Score0")}\n" +
                           $"#2:   {PlayerPrefs.GetInt("High Score1")}\n" +
                           $"#3:   {PlayerPrefs.GetInt("High Score2")}\n" +
                           $"#4:   {PlayerPrefs.GetInt("High Score3")}\n" +
                           $"#5:   {PlayerPrefs.GetInt("High Score4")}\n" +
                           $"#6:   {PlayerPrefs.GetInt("High Score5")}\n" +
                           $"#7:   {PlayerPrefs.GetInt("High Score6")}\n" +
                           $"#8:   {PlayerPrefs.GetInt("High Score7")}\n" +
                           $"#9:   {PlayerPrefs.GetInt("High Score8")}\n" +
                           $"#10:  {PlayerPrefs.GetInt("High Score9")}";
    }
}
