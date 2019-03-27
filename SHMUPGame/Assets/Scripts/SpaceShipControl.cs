using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpaceShipControl : MonoBehaviour
{
    private float Movespeed = 5f;
    private float rotationSpeed = 200f;
    private float shipRadius = 0.45f;
   // Vector3 startPosition = new Vector3(0f, 0f, 0f);
    public bool startGame;
    public Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
        //startPosition = transform.position;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(GameObject.FindWithTag("Pkey"));
            startGame = true;
        }

        if (startGame)
        {

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                this.gameObject.transform.Translate(Vector3.up * Movespeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                this.gameObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                this.gameObject.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);



            Vector3 pos = transform.position;

            if (pos.y + shipRadius >= Camera.main.orthographicSize)
            {
                pos.y = Camera.main.orthographicSize - shipRadius;
            }
            if (pos.y - shipRadius <= -Camera.main.orthographicSize)
            {
                pos.y = -Camera.main.orthographicSize + shipRadius;
            }

            float screenRatio = (float)Screen.width / (float)Screen.height;
            float widthOrtho = Camera.main.orthographicSize * screenRatio;

            if (pos.x + shipRadius >= widthOrtho)
            {
                pos.x = widthOrtho - shipRadius;
            }
            if (pos.x - shipRadius <= -widthOrtho)
            {
                pos.x = -widthOrtho + shipRadius;
            }

            transform.position = pos;
        }

    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Enemy" && collidedWith != null)
        {
            Destroy(collidedWith);
            LivesScript.lives -= 1;
            if (LivesScript.lives > 0)
            {
                StartCoroutine(Respawn());
            }
        }
    }

    IEnumerator Respawn()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(3);
        Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 pos = Camera.main.ScreenToWorldPoint(position);
        this.gameObject.GetComponent<Renderer>().enabled = true;
        transform.position = pos;
    }
}
