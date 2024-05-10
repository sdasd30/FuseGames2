using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLeft : MonoBehaviour
{
    private float scrollSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(-scrollSpeed, 0f, 0f);
        transform.Translate(movement * Time.deltaTime, Space.World);
        if (transform.position.x <= -7)
        {
            Destroy(this.gameObject);
        }
    }
}
