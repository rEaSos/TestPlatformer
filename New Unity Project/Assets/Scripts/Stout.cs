using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stout : MonoBehaviour
{
    public Controls_2 c;
    public GameObject Player;
   
    public void Start()
    {
        if (c.character == "Stout")
        {
            ImStout();
        }
    }
    public void ImStout()
    {
        Player.transform.localScale = new Vector2(2.5f, 1.4f);
        //stout.SetActive(true);
        c.speed = 5.5f;
        c.jumpForce = 15f;
        c.extraJumpsValue = 1;
    }
}
