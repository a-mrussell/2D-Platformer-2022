using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLevelManager : MonoBehaviour
{

    public static int gameLevel;

    public GameObject gameData;

    public void Awake()        
    {
        if (SceneManager.GetActiveScene().name.Equals("Level 1") && gameLevel == 0)
        {
            PlaySavedGame();
        } 
    } //This means if the game is played from the first level it will run the saved game data.

    public static void NewGameLevel()
    {
        gameLevel = 1;
        SceneManager.LoadScene(gameLevel);
    }

    public void PlaySavedGame()
    {
        gameData.GetComponent<GameData>().LoadLevelPlay();
        SceneManager.LoadScene(gameLevel); //loads the game level from the save
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }



}
