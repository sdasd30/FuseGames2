using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shootObject;
    public float maxSpeed = 5f;
    float speed = 5f;
    public LayerMask ground;
    public float holdJumpTime = .20f;
    Rigidbody2D mbody;
    public bool grounded = true;
    private bool isJumping;
    private bool isHoldingJump;
    public float hoverSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        mbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(isHoldingJump)
        {
            mbody.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        grounded = IsGrounded();
        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            holdJumpTime = .2f;
            Debug.Log("Jump");
            mbody.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) && isJumping) 
        {

            holdJumpTime -= Time.deltaTime;
            if (holdJumpTime > 0)
            {
                Debug.Log("holdJumpTime");
                isHoldingJump = true;
            }
            else
            {
                isHoldingJump = false;
                isJumping = false;
            }    
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log(holdJumpTime);
            isHoldingJump = false;
            isJumping = false;
            holdJumpTime = 0;
        }
        //speed = maxSpeed;
        //if (jumpHoldInput)
        //{
        //    grounded = IsGrounded();
        //    if (grounded)
        //    {
        //        mbody.velocity = new Vector2(0, 3f);
        //        jumpHoldInput = true;
        //        isJumping = true;
        //        Invoke("JumpHoldEnd", holdJumpTime);
        //    }
        //}

        //if (jumpHoldInput)
        //{
        //    if (!grounded && isJumping)
        //    {
        //        mbody.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
        //    }
        //}

        //if (!grounded && Input.GetKey(KeyCode.UpArrow) && mbody.velocity.y <= 0)
        //{
        //    mbody.velocity = Vector3.ClampMagnitude(mbody.velocity, hoverSpeed);
        //}


        if (Input.GetKey(KeyCode.Space))
        {
            shootObject.SetActive(true);
            speed = 2f;
        }   
        else
        {
            shootObject.SetActive(false);
            speed = 5f;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 1.13f, ground);
        bool isGrounded = hit.collider != null;
        // It is soo easy to make misstakes so do a lot of Debug.DrawRay calls when working with colliders...
        Debug.DrawRay(transform.position, Vector2.down * 1.13f, isGrounded ? Color.green : Color.red, 0.1f);
        return isGrounded;
    }
    
    public float GetSpeed()
    {
        return speed;
    }
}
