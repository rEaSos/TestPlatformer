using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;
    public bool MoveRight;
    public float Timer;
    public float MaxTimer = 2;
    public int health;
    public GameObject enemy;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= MaxTimer)
        {
            Timer = 0;
            MoveRight = !MoveRight;
        }
        Vector3 vel = rb.velocity;
        if (MoveRight) vel.x = Speed;
        else vel.x = -Speed;
        rb.velocity = vel;
        //enemy death
        if(health < 0)
        {
            enemy.transform.position = new Vector2(9999, 9999);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("DAMAGE");
    }

}
