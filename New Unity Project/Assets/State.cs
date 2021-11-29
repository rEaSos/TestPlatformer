using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    public enum PlayerState
    {
        None = 0,
        Idle = 1,
        Moving = 2,
        Jumping = 3,
        Diving = 4,
        Sliding = 5,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerState state = PlayerState.Idle;

        //move



        //jump & air jump
    }
}
