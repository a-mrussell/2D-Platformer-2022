using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySet : MonoBehaviour
{

    public static int diffculty;

    public void SDEasy() //set difficulty to easy
    {
        diffculty = 1;
    }
    
    public void SDNormal() //set difficulty to normal
    {
        diffculty = 2;
    }
    
    public void SDHard() //set difficulty to hard
    {
        diffculty = 3;
    }
}
