using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private GameObject healthItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("qwertyuiop");
            if (Input.GetButtonDown("PickUp"))
            {
                Debug.Log("jkkkkkkk");
                healthItem.SetActive(false);
            }
        }
    }


}
