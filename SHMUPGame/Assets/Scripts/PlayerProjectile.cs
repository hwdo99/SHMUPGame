﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Rigidbody2D projectile;
    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Rigidbody2D>();
        projectile.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (pos.y >= Camera.main.orthographicSize)
        {
            Destroy(this.gameObject);
        }
        if (pos.y <= -Camera.main.orthographicSize)
        {
            Destroy(this.gameObject);
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x >= widthOrtho)
        {
            Destroy(this.gameObject);
        }
        if (pos.x <= -widthOrtho)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Enemy" && collidedWith != null)
        {
            SFXManage.instance.PlayDestroyEnemySFX();
            Destroy(collidedWith);
            Destroy(this.gameObject);
            TimerControl.currentTime += 1;
            ScoreScript.currentScore += 5;
        }
    }
}
