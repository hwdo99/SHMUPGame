using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    private float speed;
    private bool startGame;
    public GameObject powerUpIcon;
    float spawnDelay = 20f;


    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!startGame)
            {
                startGame = true;
                InvokeRepeating("SpawnPowerUps", 10f, spawnDelay);
            }

        }
    }

    void SpawnPowerUps()
    {
        Vector3 position = new Vector3(Random.Range(75, (Screen.width)-75), Random.Range(75, (Screen.height)-75), 1);
        Vector3 pos = Camera.main.ScreenToWorldPoint(position);
        Instantiate(powerUpIcon, pos, Quaternion.identity);
    }
}