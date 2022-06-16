using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : MonoBehaviour
{
    public Animator animator;
    public pauseMenu PM; 

    public bool characterIsDead = false;

    void characterAnimator()
    {
        if (!PM.GamePaused) //only run this code while the pause menu is not active
        {

            if (PlayerHealth.playerDead) // if my player is dead set the animation to this
            {
                animator.SetBool("death", true);
                Debug.Log("dead");
            }
            else if (!PlayerHealth.playerDead) //if my character is not dead run this
            {
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
                    Debug.Log("is jumping");
                }
                else if (!playerController.isJumping) 
                {
                    animator.SetBool("Jump", false);
                }

                else if (Input.GetKey(KeyCode.LeftShift)) //sprint
                {
                    animator.SetFloat("Speed", 2);
                }
            
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
