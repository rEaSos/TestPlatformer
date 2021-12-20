using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stout : MonoBehaviour
{
    public Controls_2 c;
    public float hoverTime = 2f;
    public float hoverCounter;
    public BoxCollider2D bc;
    
    public void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        if (c.character == "Stout")
        {
            ImStout();
            hoverTime = hoverCounter;
        }
    }
    public void ImStout()
    {
        bc.size = new Vector2(2.5f, 1.4f);
        c.speed = 6f;
        c.jumpForce = 14f;
        c.extraJumpsValue = 1;
    }

    public void StoutHover()
    {
        hoverCounter -= Time.deltaTime;
        Vector3 vel = c.rb.velocity;
        if (hoverCounter > 0)
        {
            vel.y = 0;
            c.rb.gravityScale = 0;
        }
        else
        {
            c.rb.gravityScale = 2.75f;
            //c.SetState(Controls_2.PlayerState.Jumping);
        }
        c.rb.velocity = vel;
    }

    public void StoutHoverRefresh()
    {
        hoverCounter = hoverTime;
    }
}
