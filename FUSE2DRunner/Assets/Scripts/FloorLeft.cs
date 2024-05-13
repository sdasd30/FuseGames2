using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLeft : MonoBehaviour
{
    PlayerController player;
    float leftBound = -15f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x - player.GetSpeed() * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x <= leftBound)
        {
            this.transform.position = new Vector3(15, this.transform.position.y, this.transform.position.z);
        }
    }
}
