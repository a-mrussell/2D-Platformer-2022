using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class SavedGameData
{

    public int gameLevel;


    public SavedGameData (GameData gameData)
    {
        gameLevel = gameData.gameLevel;
        
    }

}
