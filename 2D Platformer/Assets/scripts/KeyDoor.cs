using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyDoor : MonoBehaviour
{
    public static int keys; //number of keys the player has
    public GameObject door; 
    public GameObject keySprite;
    [SerializeField] string numKeys;
    public TMP_Text numKeyText; 
    [SerializeField] bool doorOpening = false;
    [SerializeField] Rigidbody2D DoorRB;
    [SerializeField] Collider2D BC;

    private void Start()
    {
        DoorRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void changeKeyNumberUI()
    {
        numKeys = keys.ToString();
        numKeyText.text = "Keys:" + numKeys;
    }

    private void FixedUpdate() {
        if (doorOpening)
        {
            DoorRB.velocity = new Vector2 (0, DoorRB.velocity.y +1);
            BC.enabled = false;

            if (door.transform.position.y >= 10 )
            {
                doorOpening = false;
                door.SetActive(false);
            }
        }
    }

    private void Awake()
    {
        changeKeyNumberUI();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && gameObject.tag =="Key") //if player collides with key
        {
            if (Input.GetButton("PickUp"))
            { 
                keys += 1; // adds a key
                keySprite.SetActive(false); //deactivates the key sprite
                changeKeyNumberUI();
            }
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "LockedDoor") // if the player collides with a door and has a key
        {
            if (keys > 0)
            {
                if (Input.GetButton("PickUp"))
                {
                    keys -= 1; //removes 1 key
                    changeKeyNumberUI();
                    doorOpening = true;
                }
            }
        }
    }
}
