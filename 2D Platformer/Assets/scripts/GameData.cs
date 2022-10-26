using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public int savedGameLevel; //game level
    public string savedGameFileName;
    public int savedDiff;

    public int savedDeaths;
    public float savedTimeCount;

    void Awake() {
        if (SceneManager.GetActiveScene().name.Equals("Level 1"))
        {
            LoadLevelPlay();
            sceneLevelManager.gameLevel = 1;
            SaveLevel();
        }
        if (SceneManager.GetActiveScene().name.Equals("Level 2"))
        {
            LoadLevelPlay();
            sceneLevelManager.gameLevel = 2;
            SaveLevel();
        }
        if (SceneManager.GetActiveScene().name.Equals("Credits"))
        {
            LoadLevelPlay();
            sceneLevelManager.gameLevel = 3;
            SaveLevel();
        }
    }


    public void SaveLevel () //saves all the data. changes all the saved data to the current data.
    {
        Debug.Log("saved game");
        savedGameLevel = sceneLevelManager.gameLevel;

        savedGameFileName = NameGameFile.fileSaveName;

        savedDiff = DifficultySet.diff;

        savedDeaths = PlayerHealth.NumOfDeaths;
        savedTimeCount = timer.timeCount;

        SaveSystem.SaveLevel(this); //saves the data
    }

    public void LoadLevelPlay() // this pulls all the saved data and chnages everything to equal that information.
    {
        SavedGameData data = SaveSystem.LoadLevel(); //pulls the data from the savefile

        savedGameLevel = data.savedGameLevel; //loads the data
        savedGameFileName = data.savedGameFileName;
        savedDiff = data.savedDiff;
        savedDeaths = data.savedDeaths;
        savedTimeCount = data.savedTimeCount;

        sceneLevelManager.gameLevel = savedGameLevel;
        NameGameFile.fileSaveName = savedGameFileName;;
        DifficultySet.diff = savedDiff;
        PlayerHealth.NumOfDeaths = savedDeaths;
        timer.timeCount = savedTimeCount;
        
    }

}
