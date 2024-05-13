using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter Collider");
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
