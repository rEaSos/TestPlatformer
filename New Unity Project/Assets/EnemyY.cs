using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyY : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;
    public bool MoveUp;
    public float Timer;
    public float MaxTimer = 2;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= MaxTimer)
        {
            Timer = 0;
            MoveUp = !MoveUp;
        }
        Vector3 vel = rb.velocity;
        if (MoveUp) vel.y = Speed;
        else vel.y = -Speed;
        rb.velocity = vel;
    }
}
