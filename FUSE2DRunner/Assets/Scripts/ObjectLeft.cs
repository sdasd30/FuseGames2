using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLeft : MonoBehaviour
{
    GameManager gm;
    float leftBound = -15f;
    public bool primary = false;
    public float speedModifier = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x - (gm.WorldSpeed + speedModifier) * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x <= leftBound)
        {
            if (primary)
            {
                FindObjectOfType<SegmentSpawner>().SpawnSegment();
                Destroy(transform.parent.transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
