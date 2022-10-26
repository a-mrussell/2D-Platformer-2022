using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class SavedGameData
{

    public int savedGameLevel;
    public int savedDiff;
    public string savedGameFileName;
    public int savedDeaths;
    public float savedTimeCount;


    public SavedGameData (GameData gameData)
    {
        savedGameLevel = gameData.savedGameLevel; // makes the current game level equal to the saved game level
        savedDiff = gameData.savedDiff;  // makes the current game difficulty equal to the saved game difficulty
        savedGameFileName = gameData.savedGameFileName;  // makes the current game file name equal to the saved game file name

        savedDeaths = PlayerHealth.NumOfDeaths;
        savedTimeCount = timer.timeCount;
        
    }

}
