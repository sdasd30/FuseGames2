using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool friendly = false;
    public float speed;
    public float lifespan;
    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        lifespan -= Time.deltaTime;
        if (lifespan <=0)
        {
            Destroy(this.gameObject);
        }

        // Destroy the projectile if it goes out of the screen
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the projectile if it collides with something
        Destroy(gameObject);
    }
}
