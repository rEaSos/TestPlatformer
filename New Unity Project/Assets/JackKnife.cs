using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackKnife : MonoBehaviour
{
    private Controls cont;

    private Rigidbody2D rb;
    //public float surfForceX;
    //public float surfForceY;
    public Vector3 forceForward;
    // Start is called before the first frame update
    void Start()
    {
        cont = GetComponent<Controls>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //rb.velocity = new Vector2(surfForceX, surfForceY);
            rb.AddForce(forceForward, ForceMode2D.Impulse);

            if (cont.facingRight == false) // flip sprites when facing left
            {
                //surfForceX = -surfForceX;
                rb.AddForce(-forceForward, ForceMode2D.Impulse);
            }
        }
    }
}
