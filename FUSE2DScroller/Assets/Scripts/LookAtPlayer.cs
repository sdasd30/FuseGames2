using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Transform target;
    public float rotationSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = FindObjectOfType<SpaceshipController>().transform;
        }
        else
        {
            Vector3 direction = target.position - transform.position;
            if (direction != Vector3.zero)
            {
                // Calculate the angle between the turret's forward vector and the direction vector
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Apply the rotation gradually
                Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
