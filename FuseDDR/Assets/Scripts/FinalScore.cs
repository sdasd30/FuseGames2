using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    Score finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = finalScore.score.ToString();
    }
}
