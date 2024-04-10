using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speed : MonoBehaviour
{
    Rigidbody playerMovement;
    TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody>();
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string speed = string.Format("{0:F1}", playerMovement.velocity.x);
        tmp.text = speed + " m/s";
    }
}
