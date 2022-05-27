using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameGameFileOne : MonoBehaviour
{
    public string saveFileNameOne;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StoreName()
    {
        saveFileNameOne = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = saveFileNameOne;
    }
}
