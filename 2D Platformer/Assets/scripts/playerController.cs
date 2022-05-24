using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // refrencing gameobject componenet rigid body
    private Rigidbody2D rb;
    
    public float moveSpeed = 0.2f; //movespeed of my character
    private float jumpForce = 10f; //jumpforce of the character
    
    
    private bool isJumping; //to tell if the character is jumping or not
    private float moveHorizontal;

    private float targetSpeed = 10f; //topspeed of my character
    private float sprintSpeed = 15f; //sprint speed

    private float accelRate = 2f;
    private float deaccelRate = 5f;

    //for the animator and flip animation
    public Animator animator;

    private float fallMultiplier = 2.5f; //standard fall
    private float lowJumpMultiplier = 2f; //small jump fall


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        isJumping = false;
    }

    void FixedUpdate()
    {

        //jumping

        if (moveSpeed >= targetSpeed)//increases rate at which the character falls if characeter is already moving
        {
            fallMultiplier = 7f;
        }
        else
        {
            fallMultiplier = 3f;
        }

        if (rb.velocity.y < 0) //big jump 
        {
            rb.velocity += Vector2.up *Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Vertical")) //small jump
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
        }
        
        //moving
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y );

    
        if (Input.GetButton ("Horizontal"))
        {

            if (Input.GetKey(KeyCode.LeftShift)) // sprint
            {
                targetSpeed = sprintSpeed;
            }
            else //stop sprint
            {
                targetSpeed = 10f;
            }

            if (moveSpeed < targetSpeed) //if my movespeed is under the top speed it will accelerate until it is at that speed while the sideways buttons are pressed.
            {
                moveSpeed += accelRate;
            }
            else if (moveSpeed > targetSpeed) //If i stop sprint will reduce back to target speed.
            {
                moveSpeed = targetSpeed;
            }
        }
        else 
        {
            moveSpeed -= deaccelRate; //if there is no button pressed sideways the movespeed is deaccerlerated unitil 0.2
            if (moveSpeed < 0.2f )
            {
                moveSpeed = 0.2f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping) //check to see that it is not jumping
        {
            if (Input.GetButtonDown ("Vertical"))
            {
                rb.velocity = Vector2.up * jumpForce; //makes characeter jump

            }
        }

        moveHorizontal = Input.GetAxisRaw("Horizontal");

        #region animator 
        //sets character animations 
        if(moveHorizontal >= 0.1f && !isJumping)
        {
            animator.SetFloat("Speed", 1);
            transform.eulerAngles = new Vector2(0,0);
        }
        if (isJumping)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        if (moveHorizontal <= -0.1f && !isJumping)
        {
            animator.SetFloat("Speed", 1);
            transform.eulerAngles = new Vector2(0,180); 
        }
        if (moveHorizontal == 0f)
        {
           animator.SetFloat("Speed", 0); 
        }

        else if (Input.GetKey(KeyCode.LeftShift)) //sprint
        {
            animator.SetFloat("Speed", 2);
        }
        #endregion

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")//if charcater is on the platform it is not jumping
        {
            isJumping = false;
        }

    }

    void OnTriggerExit2D(Collider2D collision) //if charcater is not on the platform it is jumping
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
