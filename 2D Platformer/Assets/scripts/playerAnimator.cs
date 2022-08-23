using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : MonoBehaviour
{
    public Animator animator;
    public pauseMenu PM; 


    void characterAnimator()
    {
        if (!PM.GamePaused) //only run this code while the pause menu is not active
        {   

            if (Attacking.shooting)
            {
                animator.SetBool("shooting", true);
            }
            else if(!Attacking.shooting)
            {
                animator.SetBool("shooting", false);
            }

            if (playerController.moveHorizontal == 0f) //sets my character to running animation
            {
            animator.SetFloat("Speed", 0); 
            }
            else if(!playerController.isJumping) 
            {
                animator.SetFloat("Speed", 1);
            }
            
            if (playerController.isJumping) //sets my character to jumping animation
            {
                animator.SetBool("Jump", true);
            }
            else if (!playerController.isJumping) 
            {
                animator.SetBool("Jump", false);
            }

            else if (Input.GetKey(KeyCode.LeftShift)) //sprint
            {
                animator.SetFloat("Speed", 2);
            }
            

            if (playerController.moveHorizontal > 0.1f ) //sets direction my character is facing to right 
            {
                transform.eulerAngles = new Vector2(0,0);
            }
            if (playerController.moveHorizontal < -0.1f )  //sets direction my character is facing to left
            {
                transform.eulerAngles = new Vector2(0,180);
            }
        }
    }

    void Update()
    {
        characterAnimator();
    }

}
