using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public HitZone HitZoneL;
    public HitZone HitZoneD;
    public HitZone HitZoneU;
    public HitZone HitZoneR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HitZoneL.transform.localScale = new Vector3(.9f, .9f);
            HitZoneL.AttemptHit();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            HitZoneL.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HitZoneD.transform.localScale = new Vector3(.9f, .9f);
            HitZoneD.AttemptHit();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            HitZoneD.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HitZoneU.transform.localScale = new Vector3(.9f, .9f);
            HitZoneU.AttemptHit();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            HitZoneU.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HitZoneR.transform.localScale = new Vector3(.9f, .9f);
            HitZoneR.AttemptHit();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            HitZoneR.transform.localScale = new Vector3(1f, 1f);
        }
    }
}
