using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    public static float playerHealth = 5f;
    public static bool playerDead = false;

    private playerController PC;

     
    void Start()
    {
        PC = gameObject.GetComponent<playerController>();
    }
    

    
    
    //playerHealthDeath.GetComponent<playerController>().characterDeath();;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            playerHealth -= 1f;
        }

        if (collision.gameObject.tag == "HealthItem")
        {
            playerHealth = 5f;
        }

    }


    void Update()
    {
        if (playerHealth <= 0)
        {
            playerDead = true;
            //PC.enabled = false;
        }   
        else if (playerHealth > 0)
        {
            playerDead = false;
            //PC.enabled;
        } 

    }


}
