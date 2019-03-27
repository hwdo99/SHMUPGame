﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    private float speed;
    public bool startGame;
    public GameObject asteroidPrefab;
    float spawnDelay = 1.5f;
    public float horizontalOrVertical = 0.50f;
    public float leftOrRight = 0.50f;
    public float topOrBottom = 0.50f;


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
                InvokeRepeating("SpawnAsteroids", .5f, spawnDelay);
            }

        }
    }

    void SpawnAsteroids()
    {
        float HorizontalVerticalChance = Random.value;
        float LeftRightChance = Random.value;
        float TopBottomChance = Random.value;
        if (HorizontalVerticalChance <= horizontalOrVertical)
        {
            if (LeftRightChance <= leftOrRight) // spawn left
            {
                Vector3 position = new Vector3(-50, Random.Range(0, Screen.height), 1);
                Vector3 pos = Camera.main.ScreenToWorldPoint(position);
                Instantiate(asteroidPrefab, pos, Quaternion.AngleAxis(0, Vector3.forward));
            }
            else // spawn right
            {
                Vector3 position = new Vector3(Screen.width + 50, Random.Range(0, Screen.height), 1);
                Vector3 pos = Camera.main.ScreenToWorldPoint(position);
                Instantiate(asteroidPrefab, pos, Quaternion.AngleAxis(180, Vector3.forward));
            }
           
        }
        else 
        {
            if (TopBottomChance <= topOrBottom) //spawn bottom
            {
                Vector3 position = new Vector3(Random.Range(0, Screen.width), -50, 1);
                Vector3 pos = Camera.main.ScreenToWorldPoint(position);
                Instantiate(asteroidPrefab, pos, Quaternion.AngleAxis(90, Vector3.forward));
            }
            else // spawn top
            {
                Vector3 position = new Vector3(Random.Range(0, Screen.width), Screen.height + 50, 1);
                Vector3 pos = Camera.main.ScreenToWorldPoint(position);
                Instantiate(asteroidPrefab, pos, Quaternion.AngleAxis(270, Vector3.forward));
            }
        }
    }
}