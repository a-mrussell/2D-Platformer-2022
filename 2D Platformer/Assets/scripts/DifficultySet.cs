using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySet : MonoBehaviour
{
    [SerializeField] Slider sliderNum;
    public static int diff;

    void Awake()
    {
        diff = (int) sliderNum.value;
        Debug.Log ("diifset code awake ran + " +diff);
    }

    public void DiffSet()
    {
        diff = (int) sliderNum.value;
        Debug.Log(diff);
    }
}
