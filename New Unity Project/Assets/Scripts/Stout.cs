using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stout : MonoBehaviour
{
    public Controls_2 c;
    public void Start()
    {
        if (c.character == "Stout")
        {
            c.speed = 5.5f;
            c.jumpForce = 15f;
            c.extraJumpsValue = 1;     
        }
    }
}
