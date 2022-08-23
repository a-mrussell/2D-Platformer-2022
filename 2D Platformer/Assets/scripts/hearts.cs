using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hearts : MonoBehaviour
{
    [SerializeField] private GameObject heartNumberOne;
    [SerializeField] private GameObject heartNumberTwo;
    [SerializeField] private GameObject heartNumberThree;
    [SerializeField] private GameObject heartNumberFour;
    [SerializeField] private GameObject heartNumberFive;
   
    //private  image;
    public Image imageOne;
    public Image imageTwo;
    public Image imageThree;
    public Image imageFour;

    public Sprite FULLHP; //refrences image sprites 
    public Sprite NOHP; 


    void Start()
    {
        imageOne = heartNumberOne.GetComponent<Image>();
        imageTwo = heartNumberTwo.GetComponent<Image>();
        imageThree = heartNumberThree.GetComponent<Image>(); //refrences the image componenet
        imageFour = heartNumberFour.GetComponent<Image>();
    }

    void Update()
    {
       
        heartSpriteChange();
    }
   
    void Awake()
    {
        if (DifficultySet.diff ==1)
        {
            heartNumberOne.SetActive(true);
            heartNumberTwo.SetActive(true);
            heartNumberThree.SetActive(true);
            heartNumberFour.SetActive(true);
            heartNumberFive.SetActive(true);
        }
        else if (DifficultySet.diff ==2)
        {
            heartNumberOne.SetActive(true);
            heartNumberTwo.SetActive(true);
            heartNumberThree.SetActive(true);
            heartNumberFour.SetActive(false);
            heartNumberFive.SetActive(false);
        }
        else if (DifficultySet.diff ==3)
        {
            heartNumberOne.SetActive(true);
            heartNumberTwo.SetActive(false);
            heartNumberThree.SetActive(false);
            heartNumberFour.SetActive(false);
            heartNumberFive.SetActive(false);
        }
        
    }

   void heartSpriteChange()
   {

        if (DifficultySet.diff ==1)
        {
            if (PlayerHealth.playerHealthCurrent >= PlayerHealth.playerHealthConstant)
            {
                    imageOne.sprite = FULLHP;
                    imageTwo.sprite = FULLHP;
                    imageThree.sprite = FULLHP;
                    imageFour.sprite = FULLHP;
            }
            else if (PlayerHealth.playerHealthCurrent == 4 )
            { 
                imageFour.sprite = NOHP;
            }
            else if (PlayerHealth.playerHealthCurrent == 3 )
            { 
                imageThree.sprite = NOHP;
            }
            else if (PlayerHealth.playerHealthCurrent == 2 )
            { 
                imageTwo.sprite = NOHP;
            }
            else if (PlayerHealth.playerHealthCurrent == 1 )
            { 
                imageOne.sprite = NOHP;
            }
        }
        else if (DifficultySet.diff ==2)
        {
            if (PlayerHealth.playerHealthCurrent >= PlayerHealth.playerHealthConstant)
            {
                    imageThree.sprite = FULLHP;
                    imageTwo.sprite = FULLHP;
            }
            else if (PlayerHealth.playerHealthCurrent == 2 )
            { 
                imageThree.sprite = NOHP;
            }
            else if (PlayerHealth.playerHealthCurrent == 1 )
            { 
                imageTwo.sprite = NOHP;
            }

        }
   }
}
















   