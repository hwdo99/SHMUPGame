using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpProjectile : MonoBehaviour
{
    private Rigidbody2D powerUpProjectile;
    private float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        powerUpProjectile = GetComponent<Rigidbody2D>();
        powerUpProjectile.velocity = transform.up * speed;
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

        if (collidedWith.tag == "Boss" && collidedWith != null)
        {
                Boss.bossLives = 0;
                SFXManage.instance.PlayDestroyEnemySFX();
                Destroy(collidedWith);
                Destroy(this.gameObject);
                TimerControl.currentTime += 5;
                ScoreScript.currentScore += 15;
        }
    }
}

