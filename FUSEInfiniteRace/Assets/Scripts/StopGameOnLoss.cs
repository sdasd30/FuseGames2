using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameOnLoss : MonoBehaviour
{
    private Collider2D mCollider;
    public GameObject GameOverUI;
    public GameObject GameplayUI;
    private void Start()
    {
        mCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
        GameplayUI.SetActive(false);
    }
}
