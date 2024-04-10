using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public GameObject HitZoneL;
    public GameObject HitZoneD;
    public GameObject HitZoneU;
    public GameObject HitZoneR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            HitZoneL.transform.localScale = new Vector3(.9f, .9f);
        }
        else
        {
            HitZoneL.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            HitZoneD.transform.localScale = new Vector3(.9f, .9f);
        }
        else
        {
            HitZoneD.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            HitZoneU.transform.localScale = new Vector3(.9f, .9f);
        }
        else
        {
            HitZoneU.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            HitZoneR.transform.localScale = new Vector3(.9f, .9f);
        }
        else
        {
            HitZoneR.transform.localScale = new Vector3(1f, 1f);
        }
    }
}
