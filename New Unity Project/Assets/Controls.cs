using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float moveSpeed;
    public float pSpeed;
    public float jumpForce;
    public float moveInput;

    private Rigidbody2D rb;

    public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public float hangTime;
    private float hangCounter;

    public float jumpBufferLength = 0.1f;
    private float jumpBufferCount;

    public float dashDistance;
    private bool isDashing;

    private bool isBoosting;
    private bool canBoost;
    public float boostCooldown;



    public enum PlayerState
    {
        None = 0,
        Idle = 1,
        Moving = 2,
        Jumping = 3,
        Short_Hop = 4,
        Diving = 5,
        Skating = 6
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        PlayerState state = PlayerState.Idle;

        if(state == PlayerState.Diving)
        {
            rb.velocity = Vector2.down * (jumpForce * 1.1f);
            if(isGrounded == true)
            {
                //state == PlayerState.Skating;
            }
            //return;
        }

        if(state == PlayerState.Skating)
        {
            
        }

        
            //if (jumpBufferCount >= 0 &&)
             // jump & air jumps (jumpBuffer instead of isGrounded = true)
            
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                //jumpBufferCount = 0;
            
        

        if(state == PlayerState.Short_Hop)
        {
            //if (jumpBufferCount >= 0 &&) 
             // short hops & air short hops (jumpBuffer instead of isGrounded = true)
            
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                extraJumps--;
                //jumpBufferCount = 0;
            
        }

        if(state == PlayerState.Moving)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y); // move
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //check if you're grounded
        if (isGrounded) // setup coyote time while grounded
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        moveInput = Input.GetAxis("Horizontal"); // Horizontal movement is positive (right) and negative (left)
        if (facingRight == false && moveInput > 0) // flip sprites when facing left
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    
        if (hangCounter > 0f) // jumps replenish when landing (call coyote time instead of isgrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        //if (Input.GetKeyDown(KeyCode.Space)) //manage jump buffer before you touch ground
        //{
            //jumpBufferCount = jumpBufferLength;
        //}
        //else
        //{
            //jumpBufferCount -= Time.deltaTime;
        //}

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            state = PlayerState.Moving;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)// && isGrounded == true) // only jump when they have enough jumps
        {
            state = PlayerState.Jumping;
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0 && extraJumps > 0)// && isGrounded == true) // only jump when they have enough jumps
        {
            state = PlayerState.Short_Hop;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) //sword surf
        {
            if(isGrounded == false) //sword dive
            {
                state = PlayerState.Diving;
            }

            else // sword surf speed ground dash
            {
                state = PlayerState.Skating;
                
                
            }
            
            #region
           // if (Input.GetKey(KeyCode.DownArrow) && isGrounded == true)
           // {
                //slideDashCounter -= Time.deltaTime;
                //state = PlayerState.Skating;
                //moveSpeed = dashSpeed;

                //if (facingRight == true)
                //{
                   // rb.AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
                //}

                //if (facingRight == false)
                //{
                   // rb.AddForce(Vector2.left * dashSpeed, ForceMode2D.Impulse);
                //}
            //}
            #endregion

        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    
}
