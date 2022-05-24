using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject cameraTarget;

    public float cameraOffsetX; //camera offset x axis
    public float cameraOffsetY; //camera offset y axis

   void Update()
   {

    transform.position = new Vector3(
            cameraTarget.transform.position.x + cameraOffsetX, 
            cameraTarget.transform.position.y + cameraOffsetY,
            -10 
        );
        // to move camera to camera target with the camera offset
   }
}
