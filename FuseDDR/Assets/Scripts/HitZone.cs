using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    GameObject insideArrow = null;

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        insideArrow = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        insideArrow.GetComponent<Arrow>().MissNote();   
        insideArrow = null;
        Debug.Log("Exit");
    }

    public int AttemptHit()
    {
        if (insideArrow == null)
        {
            return 0;
        }
        float distance = Vector2.Distance(this.transform.position, insideArrow.transform.position);
        float score = Mathf.Lerp(101, 0, distance / 1.28f);
        int outscore = Mathf.Min(100, Mathf.RoundToInt(score));
        insideArrow.GetComponent<Arrow>().Hit();
        insideArrow = null;
        return outscore;
    }
}
