using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
    // refrencing gameobject componenet rigid body
    private Rigidbody2D rb;
    
    [SerializeField] private float moveSpeed = 0.2f; //movespeed of my character
    [SerializeField] private float topSpeed = 12.5f;
    [SerializeField] private float sprintSpeed = 15f;



    [SerializeField] private float currentMovingSpeed;


    [SerializeField] private float jumpForce = 11f; //jumpforce of the character
    
    
    public static bool isJumping; //to tell if the character is jumping or not
    public static float moveHorizontal;
    public static float verticalPositive;
    
    


    //private float targetSpeed = 12.5f; //topspeed of my character
    //private float sprintSpeed = 15f; //sprint speed

    private float accelRate = 2f;
    private float deaccelRate = 5f;

    //for the animator and flip animation
    //public Animator animator;

    [SerializeField] private float fallMultiplierConstant = 3.5f; //standard fall
    private float fallMultiplier;


    [SerializeField] private float lowJumpMultiplier = 2f; //small jump fall


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isJumping = false;
        fallMultiplier = fallMultiplierConstant;
    }

    void FixedUpdate()
    {
        if (PlayerHealth.resp)
        {
            currentMovingSpeed = 0.2f;
        }
        //jumping

        if (currentMovingSpeed >= topSpeed)//increases rate at which the character falls if characeter is already moving
        {
            fallMultiplier = fallMultiplierConstant + 5;
        }
        else
        {
            fallMultiplier = fallMultiplierConstant;
        }

        if (rb.velocity.y < 0) //big jump 
        {
            rb.velocity += Vector2.up *Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Vertical")) //small jump
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
        }

        
        if (!isJumping) //check to see that it is not jumping
        {
            if (verticalPositive > 0.1f)
            {
                rb.velocity = Vector2.up * jumpForce; //makes characeter jump
            }
        }
        
        //moving
        rb.velocity = new Vector2(moveHorizontal * currentMovingSpeed, rb.velocity.y );

    
        if (Input.GetButton ("Horizontal"))
        {

            if (Input.GetKey(KeyCode.LeftShift) && currentMovingSpeed < sprintSpeed) // sprint
            {
               currentMovingSpeed += accelRate;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && currentMovingSpeed >= sprintSpeed)
            {
                currentMovingSpeed = sprintSpeed;
            }
            else if (currentMovingSpeed > topSpeed)
            {
                currentMovingSpeed = topSpeed; 
            }
            else if (currentMovingSpeed < topSpeed)
            {
                currentMovingSpeed += accelRate;
            }

        }
        else 
        {
            currentMovingSpeed -= deaccelRate; //if there is no button pressed sideways the movespeed is deaccerlerated unitil 0.2
            if (currentMovingSpeed < 0.2f )
            {
                currentMovingSpeed = moveSpeed;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        verticalPositive = Input.GetAxisRaw("Vertical");
        
        //characterAnimator();

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

