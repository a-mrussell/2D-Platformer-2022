using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private GameObject healthItem;


    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButton("PickUp"))
            {
                Debug.Log("helath item collected");
                healthItem.SetActive(false);
                PlayerHealth.playerHealthCurrent = PlayerHealth.playerHealthConstant; //reset my health to the constant top health
            }
        }
    }


}
