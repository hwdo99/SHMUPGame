using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRespawner : MonoBehaviour
{
    public GameObject shipPrefab;
    public bool startGame;

    public void Start()
    {
        startGame = false;
    }

    public void Update()
    { 
        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(GameObject.FindWithTag("Pkey"));
            startGame = true;
        }
        if (startGame)
        {
            Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Vector3 pos = Camera.main.ScreenToWorldPoint(position);
            Instantiate(shipPrefab, pos, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Enemy" && collidedWith != null)
        {
            LivesScript.lives -= 1;
            Destroy(collidedWith);
            Destroy(this.gameObject);
            StartCoroutine("Respawn", 5f);
        }
    }

     
    IEnumerator Respawn(float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);
        Vector3 position = new Vector3(Screen.width/2, Screen.height/2, 0);
        Vector3 pos = Camera.main.ScreenToWorldPoint(position);
        Instantiate(shipPrefab, pos, Quaternion.identity);
    }
}
