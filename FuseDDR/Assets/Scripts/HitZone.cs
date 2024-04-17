using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HitZone : MonoBehaviour
{
    public Score score;
    public GameObject hitText;
    public GameObject missText;
    GameObject insideArrow = null;
    private GameObject activeText = null;

    private bool ignoreNextMiss = false;

    private void Start()
    {
        score = GetComponentInParent<Score>();
    }
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        insideArrow = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!ignoreNextMiss)
        {
            insideArrow.GetComponent<Arrow>().MissNote();
            insideArrow = null;
            if (activeText)
            {
                Destroy(activeText);
            }
            activeText = Instantiate(missText, this.transform.position, Quaternion.identity);
            score.UpdateScore(-100);
        }
        ignoreNextMiss = false;
    }

    public int AttemptHit()
    {
        if (insideArrow == null)
        {
            if (activeText)
            {
                Destroy(activeText);
            }
            activeText = Instantiate(missText, this.transform.position, Quaternion.identity);
            return -40;
        }
        ignoreNextMiss = true;
        float distance = Vector2.Distance(this.transform.position, insideArrow.transform.position);
        float score = Mathf.Lerp(101, 0, distance / 1.28f);
        int outscore = Mathf.Min(100, Mathf.RoundToInt(score));
        insideArrow.GetComponent<Arrow>().Hit();
        insideArrow = null;
        if (activeText)
        {
            Destroy(activeText);
        }
        activeText = Instantiate(hitText, this.transform.position, Quaternion.identity);
        activeText.GetComponent<TextMeshPro>().text = outscore.ToString();
        return outscore;
    }
}
