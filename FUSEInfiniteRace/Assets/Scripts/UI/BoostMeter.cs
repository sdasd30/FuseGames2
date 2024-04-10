using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostMeter : MonoBehaviour
{
    PlayerMovement playerMovement;
    Slider mSlider;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        mSlider = GetComponent < Slider > ();
    }

    // Update is called once per frame
    void Update()
    {
        mSlider.value = playerMovement.boostMeter;
    }
}
