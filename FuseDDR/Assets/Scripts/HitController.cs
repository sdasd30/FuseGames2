using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public bool disabled;
    public HitZone HitZoneL;
    public HitZone HitZoneD;
    public HitZone HitZoneU;
    public HitZone HitZoneR;
    private Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HitZoneL.transform.localScale = new Vector3(.9f, .9f);
            score.UpdateScore(HitZoneL.AttemptHit());
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            HitZoneL.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HitZoneD.transform.localScale = new Vector3(.9f, .9f);
            score.UpdateScore(HitZoneD.AttemptHit());
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            HitZoneD.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HitZoneU.transform.localScale = new Vector3(.9f, .9f);
            score.UpdateScore(HitZoneU.AttemptHit());
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            HitZoneU.transform.localScale = new Vector3(1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HitZoneR.transform.localScale = new Vector3(.9f, .9f);
            score.UpdateScore(HitZoneR.AttemptHit());
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            HitZoneR.transform.localScale = new Vector3(1f, 1f);
        }
    }
}
