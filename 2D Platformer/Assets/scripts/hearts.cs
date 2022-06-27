using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hearts : MonoBehaviour
{
    //private  image;
    public Image image;
    public Sprite FULLHP;
    public Sprite NOHP; 

    void Start()
    {
        //FULLHP = Resources.Load<Sprite>("heart_pixel");      //FULL
        //NOHP = Resources.Load<Sprite>("heart_pixel_empty");  
        image = gameObject.GetComponent<Image>();

    }

    void Update()
    {
        heartSpriteChange();
    }
   

   void heartSpriteChange()
   {
    if (!(image = gameObject.GetComponent<Image>()))
    {
        Debug.Log("I have no Image component! Fix meeeeeeeeeeeee");
    }
    else if (PlayerHealth.playerHealth > 2)
    {
        image.sprite = FULLHP;
    }
    else if (PlayerHealth.playerHealth < 2)
    {
        image.sprite = NOHP;
    }
   }
















    /*public float gravSuitLife;
    Sprite FULLHP, NOHP;
 
    void Start()
    {
        lifeBar();
 
        FULLHP = Resources.Load<Sprite>("heart_pixel");      //FULL
        NOHP = Resources.Load<Sprite>("heart_pixel_empty");         //EMPTY
 
        // Delete this when you know it's working :)
        if(Debug.isDebugBuild)
        {
            Debug.Log("FULLHP = " + FULLHP);
            Debug.Log("NOHP = " + NOHP);
        }
    }
 
    void lifeBar()
    {
        // This is the main thing here. I'm just getting it to log an error if there's no Image component.
        Image image;
        if (!(image = gameObject.GetComponent<Image>()))
            Debug.Log("I have no Image component! Fix meeeeeeeeeeeee");
   
        if (gravSuitLife == 3)
        {
            image.sprite = FULLHP;
        }
        if (gravSuitLife == 0)
        {
            image.sprite = NOHP;
        }
    }*/
}
