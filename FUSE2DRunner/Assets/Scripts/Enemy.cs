using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter Collider");
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("kill player!");
            Destroy(collision.gameObject);
        }
    }

}
