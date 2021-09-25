using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneLoader;

public class PlayerController : MonoBehaviour
{
    [Header("Move/Jump Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityForceMultiplier = 2.5f;
    [SerializeField] float fastJumpGravForceMult = 2.0f;
    private bool jumping;
    private float horizontal;
    private float jumpAxis;
    private bool isRunningRight;
    private bool isGrounded;

    [Header("References to Objects")]
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D playerFeetCol = default; // object needed to see if player's feet is on ground. 
    private Rigidbody2D rb;

    [Header("Ground Check Setup")]
    [SerializeField] Transform playerFeetPoint = default;
    [SerializeField] [Range(0, 1)] float playerFeetContactRange = 0.5f;
    [SerializeField] LayerMask interableGroundLayer = default;

    [Header("Health")]
    static float health;
    public Transform pit;



    public bool getIsRunningRight()
    {
        return isRunningRight;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isRunningRight = true;
        health = 3;
    }

    /*----------------------------------------------------------
     * UPDATE FUNCTIONS
    *///--------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        // read movement Inputs and jump inputs
        horizontal = Input.GetAxisRaw("Horizontal");
        jumpAxis = Input.GetAxisRaw("Jump");

        if (horizontal < 0)
        {
            isRunningRight = false;
        }
        

        if(Input.GetKeyDown(KeyCode.Space) && IsOurPlayerOnGround())
        {
            jumping = true;
        }

        animator.SetFloat("JumpVal", jumpAxis);
        animator.SetFloat("Speed", horizontal);
        animator.SetBool("isgrounded", isGrounded);

        if(transform.position.y < pit.transform.position.y)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            health--;
            Debug.Log(health);
        }
    }

    private void FixedUpdate()
    {
        // apply movement inputs and jump inputs
        Move(horizontal);
        Jump();
        IsOurPlayerOnGround();
    }

    /*----------------------------------------------------------
     * MOVE FUNCTION
    *///--------------------------------------------------------

    private void Move(float x)
    {
        // if player running left, flip character model
        if (x > 0 && !isRunningRight)
        {
            FlipCharacter();
        }
        else if(x < 0 && isRunningRight)
        {
            FlipCharacter();
        }
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    private void FlipCharacter()
    {
        // Switch the way the player is labelled as facing.
        isRunningRight = !isRunningRight;

        //this.transform.Rotate(0f, 180f, 0f);

        // THERE IS A VISUAL BUG WITH THE FLIPCHARACTER FUNCTION!!!!!
    }

    /*----------------------------------------------------------
     * JUMP FUNCTION
    *///--------------------------------------------------------

    private void Jump()
    {
        if (jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAxis * jumpForce);
            jumping = false;
        }

        // Mario-esque jump style
        if (rb.velocity.y < 0) // if player is falling
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (gravityForceMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fastJumpGravForceMult - 1) * Time.deltaTime;
        }
    }

    /*----------------------------------------------------------
     * CHECK FOR GROUND FUNCTION
    *///--------------------------------------------------------

    private bool IsOurPlayerOnGround()
    {
        isGrounded = false;

        Collider2D[] feetColliderContacts = Physics2D.OverlapCircleAll(playerFeetPoint.position, playerFeetContactRange, interableGroundLayer);

        foreach (Collider2D col in feetColliderContacts)
        {
            if (col != playerFeetCol)
            {
                //Debug.Log("feet touch Ground");
                isGrounded = true;
                return isGrounded;
            }
        }
        
        return isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(playerFeetPoint.position, playerFeetContactRange);
    }

    /*----------------------------------------------------------
     * ANIMATIONS
    *///--------------------------------------------------------

    public bool GetPlayerJumpingAnimationState()
    {
        return jumping;
    }


    /*----------------------------------------------------------
     * MOVING PLATFORMS
    *///--------------------------------------------------------

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("MovingPlatforms"))
        {
            this.transform.parent = col.transform;
        }
        if (col.gameObject.CompareTag("Spikes"))
        {
            health--;
            Debug.Log(health);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (col.gameObject.CompareTag("Hero"))
        {
            health--;
            Debug.Log(health);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("MovingPlatforms"))
        {
            this.transform.parent = null;
        }

        
    }



}
