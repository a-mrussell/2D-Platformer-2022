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
    if (!playerController.isJumping)
    {
        if (playerController.verticalPositive < -0.1f && cameraOffsetY >= -2f)
            {
                cameraOffsetY -= 0.2f;
            }
        
        else if (playerController.verticalPositive >= 0f && cameraOffsetY <= 2f )
            {
                cameraOffsetY += 0.5f;
            }
        else if (playerController.verticalPositive > 0f && cameraOffsetY > 2f )
            {
                cameraOffsetY = 2f;
            }
    }
        

    transform.position = new Vector3(
            cameraTarget.transform.position.x + cameraOffsetX, 
            cameraTarget.transform.position.y + cameraOffsetY,
            -10 
        );
        // to move camera to camera target with the camera offset
   }
}
