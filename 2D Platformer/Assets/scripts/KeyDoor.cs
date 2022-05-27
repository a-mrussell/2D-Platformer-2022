using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public int keys = 0;
    public GameObject door;
    public GameObject keySprite;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            keys += 1;
            keySprite.SetActive(false);

            Debug.Log("key added");

        }
        if (collision.gameObject.tag == "LockedDoor" && keys > 0)
        {
            door.SetActive(false);
            Debug.Log("door opened");

        }
    }


}
