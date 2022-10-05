using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class loadLevelSelect : MonoBehaviour
{
    [SerializeField] TMP_Text nameFileTxt;
    [SerializeField] TMP_Text diffTxt;
    [SerializeField] TMP_Text levelTxt;


    // Start is called before the first frame update
    private void difficultyIntToLevel (GameData gameData)
    {
        if (gameData.savedDiff == 1)
        {
            diffTxt.text = "EASY";
        }
        else if (gameData.savedDiff == 2)
        {
            diffTxt.text = "NORMAL";
        }
        else if (gameData.savedDiff == 3)
        {
            diffTxt.text = "HARD";
        }
    }


    public void textLoad (GameData gameData)
    {
        gameData.LoadLevelPlay();

        nameFileTxt.text = gameData.savedGameFileName;
        difficultyIntToLevel(gameData );
        levelTxt.text = gameData.savedGameLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
