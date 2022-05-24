using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLevelManager : MonoBehaviour
{

    public void PlayGame(GameData gameData)
    {
        gameData.LoadLevel();
        SceneManager.LoadScene(gameData.gameLevel);
    }



}
