using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public int savedGameLevel; //game level
    public string savedGameFileName;
    public int savedDiff;

    public GameObject saveSprite;


    public void SaveLevel () //saves all the data. changes all the saved data to the current data.
    {
        savedGameLevel = sceneLevelManager.gameLevel;

        savedGameFileName = NameGameFile.fileSaveName;

        savedDiff = DifficultySet.diff;

        SaveSystem.SaveLevel(this); //saves the data
    }

    public void LoadLevelPlay() // this pulls all the saved data and chnages everything to equal that information.
    {
        SavedGameData data = SaveSystem.LoadLevel(); //pulls the data from the savefile

        savedGameLevel = data.savedGameLevel; //loads the data
        savedGameFileName = data.savedGameFileName;
        savedDiff = data.savedDiff;

        sceneLevelManager.gameLevel = savedGameLevel;
        NameGameFile.fileSaveName = savedGameFileName;
        DifficultySet.diff = savedDiff;
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //if save sprite collides with player
        {
            saveSprite.SetActive(false); //deactivates save sprite
            SaveLevel();//saves data
            Debug.Log("eh"+ savedGameFileName + savedGameLevel + savedDiff);

        }
    }

}
