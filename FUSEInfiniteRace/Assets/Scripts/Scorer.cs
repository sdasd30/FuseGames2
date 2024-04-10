using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public float refPos;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        refPos = this.transform.position.x;
        distance = refPos - this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        distance = this.transform.position.x - refPos;
    }

    public void WarpAll(float distanceWarp)
    {
        refPos -= distanceWarp;
    }
}
