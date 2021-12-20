using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReplenish : MonoBehaviour
{
    public Controls_2 c;
    public Stout stout;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        c.extraJumps = c.extraJumpsValue + 1;
        stout.StoutHoverRefresh();
    }
}
