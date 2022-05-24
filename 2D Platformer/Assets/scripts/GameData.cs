using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public int gameLevel = 1;
    public GameObject saveSprite;

    public void SaveLevel ()
    {
        SaveSystem.SaveLevel(this);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameLevel += 1;
            saveSprite.SetActive(false);
            SaveLevel();
            SceneManager.LoadScene(gameLevel);
        }
    }

    public void LoadLevel()
    {
        SavedGameData data = SaveSystem.LoadLevel();

        gameLevel = data.gameLevel;

    }

    public void ClearData()
    {
        gameLevel = 1;
        SaveLevel();
    }
}
