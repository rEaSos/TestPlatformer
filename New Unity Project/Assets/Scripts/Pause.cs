using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public Controls_2 c;
    public GameObject jackArt;
    public GameObject stoutArt;
    public JackKnife jack;
    public Stout stout;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
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
        c.character = "Jack_Knife";
        jack.ImJack();
        jackArt.SetActive(true);
        stoutArt.SetActive(false);
        c.facingRight = true;
        c.SetState(Controls_2.PlayerState.Jumping);
        ResumeGame();
    }

    public void StoutSwap()
    {
        c.character = "Stout";
        stout.ImStout();
        jackArt.SetActive(false);
        stoutArt.SetActive(true);
        c.facingRight = true;
        c.SetState(Controls_2.PlayerState.Jumping);
        ResumeGame();
    }

    public void Restart()
    {
        c.Player.transform.position = c.spawnPoint.transform.position;
        ResumeGame();
    }
}
