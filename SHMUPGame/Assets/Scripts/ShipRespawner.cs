using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRespawner : MonoBehaviour
{
    public GameObject shipPrefab;
    public bool startGame;

    public void Awake()
    {
        startGame = false;
        shipPrefab.SetActive(true);
        Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 pos = Camera.main.ScreenToWorldPoint(position);
        Instantiate(shipPrefab, pos, Quaternion.identity);
    }

    public void Update()
    { 
        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(GameObject.FindWithTag("Pkey"));
            startGame = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Enemy" && collidedWith != null)
        {
            LivesScript.lives -= 1;
            Destroy(collidedWith);
            StartCoroutine("Respawn", 5f);
        }
    }

     
    private IEnumerator Respawn(float spawnDelay)
    {
        shipPrefab.SetActive(false);
        yield return new WaitForSeconds(spawnDelay);
        shipPrefab.SetActive(true);
        shipPrefab.transform.position = Vector3.zero;
        shipPrefab.transform.rotation = Quaternion.identity;
        shipPrefab.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        shipPrefab.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }
}
