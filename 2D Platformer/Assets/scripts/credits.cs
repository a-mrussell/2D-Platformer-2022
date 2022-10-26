using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class credits : MonoBehaviour
{

    [SerializeField] TMP_Text DeathNumTxt;
    [SerializeField] TMP_Text diffTxt;
    

    public void loadTxt (GameData gameData)
    {
        DeathNumTxt.text = gameData.savedDeaths.ToString();
        diffTxt.text = gameData.savedDiff.ToString();

    }




}
