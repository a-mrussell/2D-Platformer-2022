using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLevelManager : MonoBehaviour
{

    public static int gameLevel;

    public GameObject NLP; //next level point

    public GameObject gameData;

    public static void NewGameLevel()
    {
        gameLevel = 1;
        PlayerHealth.NumOfDeaths = 0;
        SceneManager.LoadScene(gameLevel);
        Debug.Log("I am run woo!");
    }

    public void PlaySavedGame()
    {
        gameData.GetComponent<GameData>().LoadLevelPlay();
        SceneManager.LoadScene(gameLevel); //loads the game level from the save
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    void OnTriggerStay2D(Collider2D collision) 
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButton("PickUp"))
            {
                LoadNextLevel();
                Debug.Log("next level");
                NLP.SetActive(false);
            }
        }
    }

    public void LoadNextLevel()
    {
        gameLevel += 1;
        SceneManager.LoadScene(gameLevel);
        gameData.GetComponent<GameData>().SaveLevel();
    }



}
