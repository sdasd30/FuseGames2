using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shootObject;
    public float maxSpeed = 5f;
    float speed = 5f;
    public LayerMask ground;
    public float timeSinceLastJump;
    Rigidbody2D mbody;
    public bool grounded;
    public float hoverSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        mbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = IsGrounded();
        speed = maxSpeed;
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            Jump();
        }
        else if (!grounded && Input.GetKey(KeyCode.UpArrow) && mbody.velocity.y <= 0)
        {
            mbody.velocity = Vector3.ClampMagnitude(mbody.velocity, hoverSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            shootObject.SetActive(true);
            speed = 2f;
        }   
        else
        {
            shootObject.SetActive(false);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 1.05f, ground);
        bool isGrounded = hit.collider != null;
        // It is soo easy to make misstakes so do a lot of Debug.DrawRay calls when working with colliders...
        Debug.DrawRay(transform.position, Vector2.down * 1.05f, isGrounded ? Color.green : Color.red, 0.1f);
        return isGrounded;
    }

    private void Jump()
    {
        mbody.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
    }
    
    public float GetSpeed()
    {
        return speed;
    }
}
