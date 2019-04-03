using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIconLife : MonoBehaviour
{
    float Lifetime = 5f;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
