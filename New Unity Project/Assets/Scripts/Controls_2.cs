using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_2 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public Rigidbody2D rb;
    public bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumps;
    public int extraJumpsValue;
    public float hangTime;
    private float hangCounter;
    public float jumpBufferLength;
    private float jumpBufferCounter;
    public PlayerState State;
    public Animator anim;
    public Transform spawnPoint;
    public Transform Player;
    public string character;
    public JackKnife jack;
    public Stout stout;
    
    public void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent <Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //character = "Jack_Knife";
        character = "Stout";
    }

    private void Update()
    {
        Debug.Log(character);
        //idle is the default state
        PlayerState tempState = PlayerState.Idle;
        #region Jack Knife states
        if (character == "Jack_Knife")
        {
            if (State == PlayerState.Diving) //j
            {
                jack.JackDiving();
                return;
            }
            if (State == PlayerState.Skating) //j
            {
                jack.JackSkating();
                return;
            }
            if (State == PlayerState.SkateJump) //j
            {
                jack.JackSkateJump();
            }
        }
        #endregion
        #region Stout states
        #endregion
        #region Move & Jump
        //check if you're grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //move input & flipping sprites
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            tempState = PlayerState.Moving;
        }
        #region Flip
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        #endregion
        #region Hang Time/Jump Buffer
        //before you jump, check for coyote time & jump buffer
        if (isGrounded)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
            tempState = PlayerState.Jumping;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferLength;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        #endregion
        //full hop & short hop input, and replenish jumps when grounded
        //jumps managed by coyote time & jump buffer counters
        //hangCounter acts like isGrounded == true, jumpBufferCounter acts like Input.GetKeyDown(KeyCode.Space)
        if (hangCounter > 0f) 
        {
            extraJumps = extraJumpsValue;
        }
        if (jumpBufferCounter > 0f && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            jumpBufferCounter = 0;
            tempState = PlayerState.Jumping;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && hangCounter > 0f)
        {
            rb.velocity = Vector2.up * jumpForce;
            tempState = PlayerState.Jumping;
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        #endregion
        //special inputs
        if (character == "Jack_Knife")
        {
            #region Jack Knife inputs
            if (Input.GetKey(KeyCode.DownArrow) && !isGrounded)
            {
                Vector3 vel = rb.velocity;
                if (facingRight)
                {
                    vel.x = speed;
                    vel.y = -jack.diveSpeed;
                }
                else
                {
                    vel.x = -speed;
                    vel.y = -jack.diveSpeed;
                }
                rb.velocity = vel;
                tempState = PlayerState.Diving;
            }
            //skate jump input
            if (Input.GetKeyDown(KeyCode.Space) && State == PlayerState.Skating)
            {
                Vector3 vel = rb.velocity;
                if (facingRight)
                {
                    vel.x = jack.skateSpeed;
                    vel.y = jack.skateJump;
                }
                else
                {
                    vel.x = -jack.skateSpeed;
                    vel.y = jack.skateJump;
                }
                rb.velocity = vel;
                extraJumps--;
                tempState = PlayerState.SkateJump;
            }
            #endregion
        }
        SetState(tempState);
    }

    public void SetState(PlayerState state)
    {
        if(State == state)
        {
            return;
        }
        if(state == PlayerState.Idle)
        {
            if (character == "Jack_Knife")
            {
                anim.Play("Jack_Idle");
            }
        }
        else if(state == PlayerState.Moving)
        {
            if (character == "Jack_Knife")
            {
                anim.Play("Jack_Moving");
            }
        }
        else if(state == PlayerState.Jumping)
        {
            if (character == "Jack_Knife")
            {
                anim.Play("Jack_Jumping");
            }
        }
        #region Jack Knife anims
        else if (state == PlayerState.Diving) //j
        {
            if (character == "Jack_Knife")
            {
                anim.Play("Jack_Diving");
            }    
        }
        else if(state == PlayerState.Skating) //j
        {
            if (character == "Jack_Knife")
            {
                anim.Play("Jack_Skating");
            }
        }
        else if(state == PlayerState.SkateJump) //j
        {
            
        }
        #endregion
        State = state;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    #region Jack Knife collisions
    //dive into skate & skate jump into idle collision
    private void OnCollisionEnter2D(Collision2D collision) //j
    {
        if(collision.gameObject.layer == 8) //layer #8 is for ground
        {
           if(State == PlayerState.Diving)
           {
                SetState(PlayerState.Skating);
           }
           if(State == PlayerState.SkateJump)
           {
                SetState(PlayerState.Idle);
           }
        }
    }
    #endregion

    #region dev respawn
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Player.transform.position = spawnPoint.transform.position;
        }
    }
    #endregion

    public enum PlayerState
    {
        //remember to put a , after the previously last state when adding new ones!
        None = 0,
        Idle = 1,
        Moving = 2,
        Jumping = 3,
        #region Jack Knife enums
        Diving = 4,
        Skating = 5,
        SkateJump = 6,
        #endregion
        #region Stout enums
        Hover = 7
        #endregion
    }

}
