using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{   
    public static float playerHealthCurrent;
    public static int playerHealthConstant;

    public static bool resp;


    [SerializeField] GameObject DeathScreenUI; //the death screen
    [SerializeField] GameObject pauseIcon; //the pause button
    [SerializeField] GameObject heartFolder;


    [SerializeField] playerAnimator ani;
    [SerializeField] playerController PC;


    [SerializeField] Vector3 savePointPosition;

    void Awake()
    {
        PlayerHealthSet (); //runs once on code first run
        resp = false;
    }

    void Start()
    {
        ani = gameObject.GetComponent<playerAnimator>();
        PC = gameObject.GetComponent<playerController>();

    }

    public void PlayerHealthSet()
    {
        if (DifficultySet.diff == 1)   //sets the top health for player to 5
        {
            playerHealthConstant = 5;
        }
        else if (DifficultySet.diff == 2)  //sets the top health for player to 3
        {
            playerHealthConstant = 3;
        }
        else if (DifficultySet.diff == 3)  //sets the top health for player to 1
        {
            playerHealthConstant = 1;
        }
        else    //logs and error
        {
            Debug.Log("difficulty select error");
            playerHealthConstant = 3;
        }
        
        playerHealthCurrent = playerHealthConstant;     //sets the current health to the top health
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Respawn")
        {
            savePointPosition = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
            
            Debug.Log(savePointPosition);
        }
        else if (collision.gameObject.tag == "Spikes") //if my character collides with the spikes
        {
            resp = true;
            playerHealthCurrent -= 1; //take one off of my character current health
            StartCoroutine(RespawnTeleport());
        }

    }

    IEnumerator RespawnTeleport()
    {
        
        PC.enabled = false;
        //yield return new WaitForSeconds(0.1f);
        transform.position = savePointPosition;
        yield return new WaitForSeconds(0.3f);
        PC.enabled = true;
        resp = false;
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
    }


    void playerDead()
    {
        ani.enabled = false;
        PC.enabled = false;

        DeathScreenUI.SetActive(true); //activates death screen
        Time.timeScale = 0f; //stops time so you cant move
        pauseIcon.SetActive(false); // stops showng pause button
        heartFolder.SetActive(false);
    }

    public static void takeDamage()
    {
        playerHealthCurrent -= 1;
    }


}
