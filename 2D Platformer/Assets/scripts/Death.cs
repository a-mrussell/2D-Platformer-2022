using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    /*
    public GameObject DeathScreenUI; //the death screen
    public GameObject pauseIcon; //the pause button

    private bool DeathScreenShow = false;

    // Update is called once per frame
    void Update()
    {
        /*if (PlayerHealth.playerDead) // if my player is dead with no health
        {
            DeathScreenUI.SetActive(true); //activates death screen
            Time.timeScale = 0f; //stops time so you cant move
            DeathScreenShow = true; 
            pauseIcon.SetActive(false); // stops showng pause button

        }

    }

    void playerwooDead()
    {
        Debug.Log("player died n action");
    }

    /*public void RestartPlayAgain(GameData gameData) //to play again and reset the level
    {
        if (PlayerHealth.playerDead && DeathScreenShow) //if my player is dead and the death screen is showing
        {
            gameData.LoadLevelPlay(); //getting the info for reloading the level
            SceneManager.LoadScene(gameData.gameLevel); //reloading the level
            
            Time.timeScale = 1f; //starts time again
            DeathScreenUI.SetActive(false); // sets the death screen as false
            DeathScreenShow = false;
            pauseIcon.SetActive(true); //activates the pause button again

            PlayerHealth.PlayerHealthSet();
            //PlayerHealth.playerHealth = 5f; // resets the charcaters health
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0); //exits back to main menu
    }
    */

}
