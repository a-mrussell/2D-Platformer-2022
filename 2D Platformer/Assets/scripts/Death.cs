using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject DeathScreenUI;
    public GameObject pauseIcon;

    private bool DeathScreenShow = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.playerDead)
        {
            DeathScreenUI.SetActive(true);
            Time.timeScale = 0f;
            DeathScreenShow = true;
            pauseIcon.SetActive(false);

        }

    }

    public void RestartPlayAgain(GameData gameData)
    {
        if (PlayerHealth.playerDead && DeathScreenShow)
        {
            //SaveSystem.LoadLevel();
            //SavedGameData data = SaveSystem.LoadLevel();
            //gameLevel = data.gameLevel;

            //sceneLevelManager.PlayGame();

            gameData.LoadLevelPlay();
            SceneManager.LoadScene(gameData.gameLevel);
            



            Time.timeScale = 1f;
            DeathScreenUI.SetActive(false);
            DeathScreenShow = false;
            pauseIcon.SetActive(true);
            PlayerHealth.playerHealth = 5f;
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    

}
