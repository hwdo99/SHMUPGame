using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D boss;
    private float speed;
    private float bossRadius = 1f;
    public static int bossLives = 3;


    // Start is called before the first frame update
    void Start()
    {
        bossLives = 3;
        speed = Random.Range(50f, 150f);
        boss = GetComponent<Rigidbody2D>();
        boss.velocity = transform.right * speed * Time.deltaTime;
        boss.AddTorque(Random.Range(-30f, 30f));
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (pos.y >= Camera.main.orthographicSize + bossRadius)
        {
            Destroy(this.gameObject);
        }
        if (pos.y <= -Camera.main.orthographicSize - bossRadius)
        {
            Destroy(this.gameObject);
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x >= widthOrtho + bossRadius)
        {
            Destroy(this.gameObject);
        }
        if (pos.x <= -widthOrtho - bossRadius)
        {
            Destroy(this.gameObject);
        }
    }
}
