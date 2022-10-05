using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject cameraTarget;
    public GameObject light;
    public GameObject camera;


    public float cameraOffsetX; //camera offset x axis
    public float cameraOffsetY; //camera offset y axis

    public float lightOffsetX;
    public float lightOffsetY;


   void Update()
   {
    if (!playerController.isJumping)
    {
        if (playerController.verticalPositive < -0.1f)
            {
                if (cameraOffsetY >= -2f)
                {
                    cameraOffsetY -= 0.2f; 
                    }
                if (lightOffsetY >= -4f)
                {
                    lightOffsetY -=0.2f;
                }
            }
        else if (playerController.verticalPositive >= 0f)
        {
            if (cameraOffsetY <= 2f )
            {
                cameraOffsetY += 0.5f;
            }
            else if (cameraOffsetY > 2f )
            {
                cameraOffsetY = 2f;
            }
            if (lightOffsetY <= 0f)
            {
                lightOffsetY += 0.5f;
            }
            else if (cameraOffsetY > 0f)
            {
                cameraOffsetY = 0f;
            }
        }
    }


    camera.transform.position = new Vector3
    ( 
    cameraTarget.transform.position.x + cameraOffsetX, 
    cameraTarget.transform.position.y + cameraOffsetY,
    -10     
    );
    // to move camera to camera target with the camera offset

    light.transform.position = new Vector3
    (
    cameraTarget.transform.position.x + lightOffsetX, 
    cameraTarget.transform.position.y + lightOffsetY,
    1
    );
    // to move light to target with the light offset
    
   }
}
