using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    public float fovDelta;
    public float baseFOV;
    public float maxSpeedFOV;

    private Rigidbody player;
    private PlayerMovement playerMovement;

    private Camera mCamera;

    // Start is called before the first frame update
    void Start()
    {
        mCamera = GetComponent<Camera>();
        player = GetComponentInParent<Rigidbody>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedRatio = player.velocity.x / maxSpeedFOV;
        mCamera.fieldOfView = baseFOV + (speedRatio * fovDelta);

        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, - player.transform.rotation.x);
    }
}
