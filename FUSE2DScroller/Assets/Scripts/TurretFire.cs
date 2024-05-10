using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    public GameObject projectile;
    public float cooldownMax = 3f;
    float currentCool;
    // Start is called before the first frame update
    void Start()
    {
        currentCool = cooldownMax;
    }

    // Update is called once per frame
    void Update()
    {
        currentCool -= Time.deltaTime;
        if (currentCool <= 0)
        {
            currentCool = cooldownMax;
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
