using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class credits : MonoBehaviour
{

    [SerializeField] TMP_Text DeathNumTxt;

    public void loadTxt (GameData gameData)
    {
        DeathNumTxt.text = gameData.savedDeaths.ToString();
    }




}
