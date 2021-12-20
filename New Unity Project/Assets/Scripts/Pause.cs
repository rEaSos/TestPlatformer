using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public Controls_2 c;
    public GameObject jackArt;
    public GameObject stoutArt;
    public JackKnife jack;
    public Stout stout;
    public Unlock U;
    public GameObject npcstout;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.C) && isPaused == true)
        {
            JackSwap();
        }
        if(Input.GetKeyDown(KeyCode.B) && isPaused == true)
        {
            if (U.unlock == true)
            {
                StoutSwap();
            }
        }
    }

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void JackSwap()
    {
        c.SetState(Controls_2.PlayerState.Jumping);
        c.rb.gravityScale = 2.75f;
        c.character = "Jack_Knife";
        jack.ImJack();
        jackArt.SetActive(true);
        stoutArt.SetActive(false);
        ResumeGame();
    }

    public void StoutSwap()
    {
        c.SetState(Controls_2.PlayerState.Jumping);
        c.rb.gravityScale = 2.75f;
        c.character = "Stout";
        stout.ImStout();
        jackArt.SetActive(false);
        stoutArt.SetActive(true);
        npcstout.SetActive(false);
        ResumeGame();
    }

    public void Restart()
    {
        c.Player.transform.position = c.spawnPoint.transform.position;
        ResumeGame();
    }
}
