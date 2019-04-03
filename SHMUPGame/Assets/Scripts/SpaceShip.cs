using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpaceShip : MonoBehaviour
{
    public GameObject explosionPrefab;
    private ParticleSystem engineFire;
    public GameObject projectilePrefab;
    public GameObject powerUpPrefab;
    private float Movespeed = 5f;
    private float rotationSpeed = 200f;
    private float shipRadius = 0.5f;
    private bool startGame;
    private float nextFire;
    float fireRate = 0.3f;
    float powerUpFireRate = 0.15f;
    private bool isDead;
    private bool isInvincible;
    private bool playEngine;
    public bool isPoweredUp;
    

    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
        Cursor.visible = true;
        isDead = false;
        isPoweredUp = false;
        engineFire = GetComponent<ParticleSystem>();
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
            if (!isDead)
            {
                if (!playEngine)
                {
                    engineFire.Play();
                    playEngine = true;
                }
                 
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    this.gameObject.transform.Translate(Vector3.up * Movespeed * Time.deltaTime);


                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    this.gameObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    this.gameObject.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

                if (!isPoweredUp)
                {
                    if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
                    {
                        SFXManage.instance.PlayFireSFX();
                        nextFire = Time.time + fireRate;
                        Vector3 posOfShot = new Vector3(transform.position.x, transform.position.y, 0);
                        Instantiate(projectilePrefab, posOfShot, transform.rotation);
                    }
                }
                else if (isPoweredUp)
                {
                    if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
                    {
                        SFXManage.instance.PlayPowerUpShotSFX();
                        nextFire = Time.time + powerUpFireRate;
                        Vector3 posOfShot = new Vector3(transform.position.x, transform.position.y, 0);
                        Instantiate(powerUpPrefab, posOfShot, transform.rotation);
                    }
                }
            }
            else
            {
                if (playEngine)
                {
                    engineFire.Stop();
                    playEngine = false;
                }  
            }
          
          

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        GameObject collidedWith = collision.gameObject;
        if (isInvincible)
        {
            if (collidedWith.tag == "PowerUp" && collidedWith != null)
            {
                SFXManage.instance.PlayGetPowerUpSFX();
                Destroy(collidedWith);
                StartCoroutine(PowerUp());
            }
            return;
        }

        if (collidedWith.tag == "PowerUp" && collidedWith != null)
        {
            SFXManage.instance.PlayGetPowerUpSFX();
            Destroy(collidedWith);
            StartCoroutine(PowerUp());
        }

        if ((collidedWith.tag == "Enemy" || collidedWith.tag == "Boss") && collidedWith != null)
        {
            SFXManage.instance.PlayExplosionSFX();
            Destroy(collidedWith);
            LivesScript.lives -= 1;
            TimerControl.currentTime -= 10;
            if (LivesScript.lives > 0)
            {
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn()
    {
        isDead = true;
        Color color = new Color(0, 0, 0, 0);
        GetComponent<Image>().color = color;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        var explosion = Instantiate(explosionPrefab, pos, transform.rotation);
        yield return new WaitForSeconds(4);
        Destroy(explosion);
        isDead = false;
        isInvincible = true;
        GetComponent<Image>().color = new Color(50 / 100f, 50 / 100f, 1, 1); // make color different when invincible
        yield return new WaitForSeconds(3); // gain invincibility for 3 seconds after respawning
        isInvincible = false; // invincibility wears off
        GetComponent<Image>().color = Color.white;
    }

    private IEnumerator PowerUp()
    {
        isPoweredUp = true;
        GetComponent<Image>().color = new Color(255, 0, 235, 255); // make color different when powered up
        yield return new WaitForSeconds(7f);
        isPoweredUp = false;
        GetComponent<Image>().color = Color.white;
    }
}
