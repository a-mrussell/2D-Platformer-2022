using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameGameFile : MonoBehaviour
{
    public TMP_InputField inF; //the textinput field

    [SerializeField] GameObject warningScreen; //the warning screen UI

    public static string fileSaveName;

    [SerializeField] string wordTest;

    string strrr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ "; //the ONLY characters that the name must contain


    public void GameFileNaming(GameData gameData) //pulls the saved game data
    {

        fileSaveName = inF.text;
        if (fileSaveName.Equals(""))
        {
            Debug.Log("no name file");
            warningScreen.SetActive(true);
            gameObject.SetActive(false);           
        }
        else
        {
            sceneLevelManager.NewGameLevel();
            gameData.SaveLevel();
        }
    }

    public void characterCheck() //this runs for each character to see if it is acceptable
    {
        char[] str = strrr.ToCharArray();

        wordTest = inF.text;
        wordTest = wordTest.ToUpper();
        char[] nameSplit = wordTest.ToCharArray();

        for (int i = 0; i< nameSplit.Length; i++) //runs for the length of the game name
            for (int x = 0; x <str.Length; x++) //runs for the length of the acceptable characters
                if (nameSplit[i].Equals(str[x])) //if the character is acceptable 
                {
                    x = str.Length;
                }
                else if (x == 26) //if the character is unacceptable 
                {
                    Debug.Log("error not a character within A-Z");
                    inF.text = ""; //changes the name file to empty
                    i = nameSplit.Length;

                    warningScreen.SetActive(true);
                    gameObject.SetActive(false);
                }
    }
}
