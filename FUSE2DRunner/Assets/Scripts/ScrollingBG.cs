using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    GameManager gm;
    Vector2 RestartPos = new Vector2(19.6f, 0);
    float leftBound = -19.6f;
    public float speedModifier = -.2f;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x - (gm.WorldSpeed + speedModifier) * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x <= leftBound)
        {
            this.transform.position = RestartPos;
        }
    }
}
