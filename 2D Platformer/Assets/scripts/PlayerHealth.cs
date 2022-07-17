using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{   
    [SerializeField] float playerHealthCurrent;
    public static int playerHealthConstant;

    [SerializeField] GameObject DeathScreenUI; //the death screen
    [SerializeField] GameObject pauseIcon; //the pause button

    [SerializeField] playerAnimator ani;
    [SerializeField] playerController PC;

    [SerializeField] bool DeathScreenShow = false;


    void Awake()
    {
        PlayerHealthSet (); //runs once on code first run
    }

    void Start()
    {
        ani = gameObject.GetComponent<playerAnimator>();
        PC = gameObject.GetComponent<playerController>();
    }

    public void PlayerHealthSet()
    {
        if (DifficultySet.diffculty == 1)   //sets the top health for player to 5
        {
            playerHealthConstant = 5;
        }
        else if (DifficultySet.diffculty == 2)  //sets the top health for player to 3
        {
            playerHealthConstant = 3;
        }
        else if (DifficultySet.diffculty == 3)  //sets the top health for player to 1
        {
            playerHealthConstant = 1;
        }
        else    //logs and error
        {
            Debug.Log("difficulty select error");
        }
        
        
        playerHealthCurrent = playerHealthConstant;     //sets the current health to the top health
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes") //if my character collides with the spikes
        {
            playerHealthCurrent -= 1; //take one off of my character current health
        }

        if (collision.gameObject.tag == "HealthItem") // if my character collides with a health item
        {
            playerHealthCurrent = playerHealthConstant; //reset my health to the constant top health
        }

    }


    void Update()
    {

        if (playerHealthCurrent <= 0) //if my character health is lower or equal to 0 my character is dead
        {
            playerDead();
        }   
        else if (playerHealthCurrent > playerHealthConstant) //if my character health is above  0 my character is not dead
        {
            playerHealthCurrent = playerHealthConstant;
        } 
        else if (playerHealthCurrent > 0)
        {
            //do something here
        }

    }

    void playerDead()
    {
        ani.enabled = false;
        PC.enabled = false;


        DeathScreenUI.SetActive(true); //activates death screen
        Time.timeScale = 0f; //stops time so you cant move
        DeathScreenShow = true; 
        pauseIcon.SetActive(false); // stops showng pause button
    }


}
