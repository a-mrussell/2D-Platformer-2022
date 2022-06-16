using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public int gameLevel = 1; //game level
    public GameObject saveSprite;


    public void SaveLevel ()
    {
        SaveSystem.SaveLevel(this); //saves the data
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //if save sprite collides with player
        {
            gameLevel += 1;
            saveSprite.SetActive(false); //deactivates save sprite
            SaveLevel();//saves data
            SceneManager.LoadScene(gameLevel);

        }
    }

    public void LoadLevelPlay()
    {
        SavedGameData data = SaveSystem.LoadLevel(); //pulls the data from the savefile

        gameLevel = data.gameLevel; //loads the data
    }

    public void ClearData()
    {
        gameLevel = 1; //resets game level to first level
        PlayerHealth.playerHealth = 5f; //resets player health to original health
        SaveLevel(); //saves data
    }
}
