using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shootObject;
    public float maxSpeed = 5f;
    float speed = 5f;
    public LayerMask ground;
    public float holdJumpTime = .3f;
    Rigidbody2D mbody;
    public bool grounded = true;
    private bool jumpHoldInput;
    private bool isJumping;
    public float hoverSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        mbody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumpHoldInput = true;
        }
        else
        {
            jumpHoldInput = false;
        }

    }

    void FixedUpdate()
    {
        
        speed = maxSpeed;
        if (jumpHoldInput)
        {
            grounded = IsGrounded();
            if (grounded)
            {
                mbody.velocity = new Vector2(0, 3f);
                jumpHoldInput = true;
                isJumping = true;
                Invoke("JumpHoldEnd", holdJumpTime);
            }
        }

        if (jumpHoldInput)
        {
            if (!grounded && isJumping)
            {
                mbody.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            }
        }

        if (!grounded && Input.GetKey(KeyCode.UpArrow) && mbody.velocity.y <= 0)
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

    private void JumpHoldEnd()
    {
        isJumping = false;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 1.01f, ground);
        bool isGrounded = hit.collider != null;
        // It is soo easy to make misstakes so do a lot of Debug.DrawRay calls when working with colliders...
        Debug.DrawRay(transform.position, Vector2.down * 1.01f, isGrounded ? Color.green : Color.red, 0.1f);
        return isGrounded;
    }


    
    public float GetSpeed()
    {
        return speed;
    }
}
