using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 90f;
    public float baseMoveSpeed = 10f;
    public float moveSpeed = 5f;
    public float boostSpeed = 30f;

    public float maxStrafeSpeed = 40f;
    public float strafeSpeed = 20f;
    public float rotationMax = 10f;
    public float rotationSpeed = 8f;
    private Quaternion defaultRotation;
    private Rigidbody mRigidBody;

    public float boostMeter = 0f;
    public float boostMax = 10f;

    void Start()
    {
        // Store the default rotation when the script starts
        defaultRotation = transform.rotation;
        mRigidBody = GetComponent<Rigidbody>();
    }   

    void FixedUpdate()
    {
        // Get input values for movement
        float forwardBack = Input.GetAxis("Vertical");
        if (forwardBack < 0)
            forwardBack = 0;
        float leftRight = Input.GetAxis("Horizontal");
        float boost = Input.GetAxis("Jump");
        float actualBoost = 0;

        float actualMaxSpeed = maxSpeed + this.transform.position.x / 1000;

        if (boost > 0)
        {
            if (boostMeter <= 0)
            {
                boostMeter = 0;
                actualBoost = 0;
            }
            else
            {
                boostMeter -= boost * 3 * Time.deltaTime;
                actualBoost = boost;
            } 
        }
        else
        {
            boostMeter += Time.deltaTime * 2;
            if (boostMeter >= boostMax) boostMeter = boostMax;
        }

        float targetForwardVelocity = baseMoveSpeed + (actualMaxSpeed * forwardBack) * (1 + (boostSpeed * actualBoost));
        float forwardForce = (targetForwardVelocity - mRigidBody.velocity.x) * moveSpeed;
        float targetStrafeVelocity = maxStrafeSpeed * -leftRight;
        float strafeForce = (targetStrafeVelocity - mRigidBody.velocity.z) * strafeSpeed;

        Vector3 force = new Vector3(forwardForce, 0, strafeForce);
        mRigidBody.AddForce(force);

        float rotationAmount = (mRigidBody.velocity.z / maxStrafeSpeed) * rotationMax;
        transform.eulerAngles = new Vector3(rotationAmount, transform.eulerAngles.y, transform.eulerAngles.z);
        
    }
}
