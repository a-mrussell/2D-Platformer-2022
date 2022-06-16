using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    public static float playerHealth = 5f;
    public static bool playerDead = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes") //if my character collides with the spikes
        {
            playerHealth -= 1f; //take one off of my character health
        }

        if (collision.gameObject.tag == "HealthItem") // if my character collides with a health item
        {
            playerHealth = 5f; //reset my health to the original health
        }

    }


    void Update()
    {
        if (playerHealth <= 0) //if my character health is lower or equal to 0 my character is dead
        {
            playerDead = true;
        }   
        else if (playerHealth > 0) //if my character health is above  0 my character is not dead
        {
            playerDead = false;
        } 

    }


}
