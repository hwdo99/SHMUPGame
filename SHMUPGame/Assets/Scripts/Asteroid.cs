using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D asteroid;
    private float speed;
    private float asteroidRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(100f, 300f);
        asteroid = GetComponent<Rigidbody2D>();
        asteroid.velocity = transform.right * speed * Time.deltaTime;
        asteroid.AddTorque(Random.Range(-30f, 30f));
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (pos.y >= Camera.main.orthographicSize + asteroidRadius)
        {
            Destroy(this.gameObject);
        }
        if (pos.y <= -Camera.main.orthographicSize - asteroidRadius)
        {
            Destroy(this.gameObject);
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x  >= widthOrtho + asteroidRadius)
        {
            Destroy(this.gameObject);
        }
        if (pos.x <= -widthOrtho - asteroidRadius)
        {
            Destroy(this.gameObject);
        }
    }
}
