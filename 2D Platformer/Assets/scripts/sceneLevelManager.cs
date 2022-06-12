using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLevelManager : MonoBehaviour
{

    public static void PlayGame(GameData gameData)
    {
        gameData.LoadLevelPlay();
        SceneManager.LoadScene(gameData.gameLevel);
    }



}
