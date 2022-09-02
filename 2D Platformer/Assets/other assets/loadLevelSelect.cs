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


    public void textLoad (GameData gameData)
    {
        gameData.LoadLevelPlay();

        nameFileTxt.text = gameData.savedGameFileName;
        diffTxt.text = gameData.savedDiff.ToString();
        levelTxt.text = gameData.savedGameLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
