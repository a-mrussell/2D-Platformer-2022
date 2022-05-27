using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseIcon;


    //runs only on first instance of the code being run 
    void Awake()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused) //if the key is pressed while the game is paused it will resume
            {
                Resume();
            }
            else // if pressed while the game is not paused it will pause the game
            {
                Pause();
            }
        }
    }
    
    public void Resume () 
    {
        pauseMenuUI.SetActive(false);// makes the pause panel inactive
        pauseIcon.SetActive(true); //makes pause icon appear
        Time.timeScale = 1f; //resumes time scale
        GamePaused = false; 
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);//makes the pause panel active
        pauseIcon.SetActive(false); //makes pause icon disappear
        Time.timeScale = 0f; //stops the time scale
        GamePaused = true;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
