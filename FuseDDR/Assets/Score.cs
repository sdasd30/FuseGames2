using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public void UpdateScore(int val)
    {
        score += val;
        scoreText.text = "Score: " + score.ToString();
    }
}
