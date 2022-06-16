using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLevelManager : MonoBehaviour
{

    public void PlayGame(GameData gameData)
    {
        gameData.LoadLevelPlay(); //pulls the game level from the save
        SceneManager.LoadScene(gameData.gameLevel); //loads the game level from the save
    }



}
