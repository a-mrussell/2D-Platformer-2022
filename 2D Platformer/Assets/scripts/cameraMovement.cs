using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject cameraTarget;
    //public Vector2 cameraOffset = new Vector2 (0,0,0);


    new float camPositionX = 0;
    new float camPositionY = 0;


   void Update()
   {
    camPositionY = cameraTarget.transform.position.y;
    camPositionX = cameraTarget.transform.position.x;

    transform.position = new Vector3(
            camPositionX, 
            camPositionY,
            -10 
        );
   }
}
