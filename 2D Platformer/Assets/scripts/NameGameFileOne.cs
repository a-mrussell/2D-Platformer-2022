using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameGameFileOne : MonoBehaviour
{
    public GameObject inputField;
    public GameObject inputText;
    public TextMeshProUGUI txt;

    [SerializeField] string fileSaveName;
    [SerializeField] string wordTrial;

    public string fond = "";


    string strrr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";


    public void NameGameFile()
    {
        Debug.Log("click");
        fileSaveName = inputField.GetComponent<TMP_Text>().text;
        Debug.Log(fileSaveName);
    }

    public void characterCheck()
    {
        char[] str = strrr.ToCharArray();

        wordTrial = inputField.GetComponent<TMP_Text>().text;
        txt = inputText.GetComponent<TextMeshProUGUI>();


        wordTrial = wordTrial.ToUpper();
        wordTrial = wordTrial.Remove(wordTrial.Length -1 ,1);
        char[] nameSplit = wordTrial.ToCharArray();
        
        for (int i = 0; i < nameSplit.Length; i++)
            for (int x = 0; x < str.Length; x++)
                if (nameSplit[i].Equals(str[x]))
                 {
                    Debug.Log("workss s s s s ");
                    x = str.Length;
                 }
                else if (x == 26)
                {
                    Debug.Log("error not a character within A-Z");
                    wordTrial = "";
                    txt.text= fond;
                    //txt.text = "wwwwww";
                }


    }



}
