using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public int keys = 0; //number of keys the player has
    public GameObject door; 
    public GameObject keySprite;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Key") //if player collides with key
        {
            keys += 1; // adds a key
            keySprite.SetActive(false); //deactivates the key sprite

            Debug.Log("key added");

        }
        if (collision.gameObject.tag == "LockedDoor" && keys > 0) // if the player collides with a door and has a key
        {
            door.SetActive(false); //deactivates the door sprite
            keys -= 1; //removes 1 key
            Debug.Log("door opened");

        }
    }


}
