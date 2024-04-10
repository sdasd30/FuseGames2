using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroy : MonoBehaviour
{
    public float destroyYPosition = -5f; // Set the Y-axis position where you want the object to be destroyed
    public Transform player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    void Update()
    {
        if (transform.position.y < destroyYPosition)
        {
            Destroy(gameObject);
        }
        if (this.transform.position.x + 100 < player.position.x)
        {
            Destroy(gameObject);
        }
    }
}
