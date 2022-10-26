using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public static float timeCount;
    [SerializeField] TMP_Text counter;
    private bool counting = true;

    // Update is called once per frame
    void Update()
    {
        if (sceneLevelManager.gameLevel == 3)
        {
            counting = false;
            Debug.Log("L3");
        }
        if (counting)
        {   
            timeCount += 1 * Time.deltaTime;
        }
         counter.text = timeCount.ToString();
    }
}
