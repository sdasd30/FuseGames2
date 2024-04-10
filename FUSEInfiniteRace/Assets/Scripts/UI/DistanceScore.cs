using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceScore : MonoBehaviour
{
    Scorer playerScore;
    Transform player;
    TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = FindObjectOfType<Scorer>();
        player = FindObjectOfType<PlayerMovement>().transform;
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string distVal = string.Format("{0:F1}", playerScore.distance);
        tmp.text = distVal + " m";
    }
}
