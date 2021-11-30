using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackKnife : MonoBehaviour
{
    public Controls_2 c;

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
            vel.y = -c.diveSpeed;
        }
        else
        {
            vel.x = -c.speed;
            vel.y = -c.diveSpeed;
        }
        c.rb.velocity = vel;
    }

    public void JackSkating()
    {
        Vector3 vel = c.rb.velocity;
        if (c.facingRight)
        {
            vel.x = c.skateSpeed;
        }
        else
        {
            vel.x = -c.skateSpeed;
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
            vel.x = c.skateSpeed;
            vel.y = c.skateJump;
        }
        else
        {
            vel.x = -c.skateSpeed;
            vel.y = c.skateJump;
        }
        c.rb.velocity = vel;
        c.extraJumps--;
    }
}
