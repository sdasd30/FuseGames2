using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EndScreen;
    public GameObject cointer;


    public float WorldSpeed { get => worldspeed; }
    private float worldspeed;
    public int Coints;

    PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            worldspeed = playerController.GetSpeed();
        }
    }

    public void CallEndScreen()
    {
        cointer.SetActive(false);
        EndScreen.SetActive(true);
    }
}
