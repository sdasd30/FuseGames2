using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Attackable : MonoBehaviour
{
    public bool friendly = false;
    public int hitpoints = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Projectile>() != null)
        {
            Projectile other = collision.gameObject.GetComponent<Projectile>();
            if(other.friendly != friendly)
            {
                hitpoints -= other.damage;
                if(hitpoints <= 0)
                {
                    Destroy(this.gameObject);
                    Debug.Log("Destroyed");
                }
                Debug.Log("Destroy projectile");
                Destroy(collision.gameObject);
            }
            Debug.Log("Ignored projectile");
        }
    }
}
