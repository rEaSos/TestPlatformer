using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    //private float cPointNumber = 1;
    public GameObject Respawn;
    public GameObject cp1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cPointNumber += 1;
        Respawn.transform.position = this.transform.position;
    }
}
