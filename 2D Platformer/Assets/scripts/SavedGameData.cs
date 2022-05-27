using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class SavedGameData
{

    new public int gameLevel;
    //new public string test;


    public SavedGameData (GameData gameData)
    {
        gameLevel = gameData.gameLevel;
        //test = gameData.test;
        
    }

}
