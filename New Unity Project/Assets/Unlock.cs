using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public Pause pause;
    public GameObject stoutButton;
    public GameObject text;
    public GameObject stoutText;
    public bool unlock = false;
    public Controls_2 c;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        unlock = true;
        if(unlock == true)
        {
            stoutButton.SetActive(true);
            text.SetActive(true);
        }
    }
}
