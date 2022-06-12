using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : MonoBehaviour
{
    public Animator animator;
    public pauseMenu PM;

    //public static playerController PC;
    //public static PlayerHealth PHS;

    public bool characterIsDead = false;

    void characterAnimator()
    {
        if (!PM.GamePaused)
        {

            if (PlayerHealth.playerDead) 
            {
                animator.SetBool("death", true);
                Debug.Log("dead");
            }
            else if (!PlayerHealth.playerDead)
            {
                if (playerController.moveHorizontal == 0f)
                {
                animator.SetFloat("Speed", 0); 
                }
                else if(!playerController.isJumping)
                {
                    animator.SetFloat("Speed", 1);
                }
                
                if (playerController.isJumping)
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

            if (playerController.moveHorizontal > 0.1f )    
            {
                transform.eulerAngles = new Vector2(0,0);
            }
            if (playerController.moveHorizontal < -0.1f )  
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
