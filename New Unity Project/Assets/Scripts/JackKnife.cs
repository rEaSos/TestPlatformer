using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackKnife : MonoBehaviour
{
    public Controls_2 c;
    public float diveSpeed = 15f;
    public float skateSpeed = 15f;
    public float skateJump = 17f;
    public void Start()
    {
        if (c.character == "Jack_Knife")
        {
            c.speed = 8f;
            c.jumpForce = 12f;
            c.extraJumpsValue = 1;
        }
    }

    public void JackDiving()
    {
        Vector3 vel = c.rb.velocity;
        if (c.facingRight)
        {
            vel.x = c.speed;
            vel.y = -diveSpeed;
        }
        else
        {
            vel.x = -c.speed;
            vel.y = -diveSpeed;
        }
        c.rb.velocity = vel;
    }

    public void JackSkating()
    {
        Vector3 vel = c.rb.velocity;
        if (c.facingRight)
        {
            vel.x = skateSpeed;
        }
        else
        {
            vel.x = -skateSpeed;
        }
        c.rb.velocity = vel;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            c.SetState(Controls_2.PlayerState.SkateJump);
        }
    }

    public void JackSkateJump()
    {
        Vector2 vel = c.rb.velocity;
        if (c.facingRight)
        {
            vel.x = skateSpeed;
            vel.y = skateJump;
        }
        else
        {
            vel.x = -skateSpeed;
            vel.y = skateJump;
        }
        c.rb.velocity = vel;
        c.extraJumps--;
    }
}
