using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // refrencing gameobject componenet rigid body
    private Rigidbody2D rb;
    
    public float moveSpeed = 0.1f;
    public float jumpForce = 10f;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    public float targetSpeed = 15f;

    public float accelRate = 3f;
    public float deaccelRate = 1f;

    //for the animator and flip animation
    public Animator animator;

    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2f;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        isJumping = false;
    }

    void FixedUpdate()
    {

        #region Trial
        /*
        float targetSpeed = moveHorizontal * moveSpeed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deaccerleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        rb.AddForce(movement * Vector2.right); */
        #endregion

        if (moveSpeed >= targetSpeed)
        {
            fallMultiplier = 7f;

        }
        else
        {
            fallMultiplier = 3f;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up *Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Vertical"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
        }
        
        
        //if (rb.velocity.x != 0 )
        //{
            rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y );
            if (Input.GetButton ("Horizontal"))
            {
                //rb.velocity = Vector2.right * moveSpeed;

                if (moveSpeed <= targetSpeed)
                {
                    moveSpeed += accelRate;
                }
            }
            else 
            {
                moveSpeed -= deaccelRate;
                if (moveSpeed < 0.2f )
                {
                    moveSpeed = 0.2f;
                }
            }
        //}

        //rb.velocity = new Vector2(moveHorizontal * moveSpeed * Time.deltaTime, rb.velocity.y );

        /*if (!isJumping && moveVertical > 0.1f )
        {
            rb.AddForce(new Vector2(0f , moveVertical * jumpForce), ForceMode2D.Impulse);
        }*/



    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping)
        {
            if (Input.GetButtonDown ("Vertical"))
            {
                rb.velocity = Vector2.up * jumpForce;

            }
        }






        /*if (Input.GetButtonDown ("Horizontal"))
        {
            rb.velocity = Vector2.right * moveSpeed;
        }*/









        moveHorizontal = Input.GetAxisRaw("Horizontal");
        /*moveVertical = Input.GetAxisRaw("Vertical");*/

        #region animator
        if(moveHorizontal > 0.1f && !isJumping)

        {
            animator.SetFloat("Speed", 1);
            transform.eulerAngles = new Vector2(0,0);
        }
        if (moveHorizontal < -0.1f && !isJumping)
        {
            animator.SetFloat("Speed", 1);
            transform.eulerAngles = new Vector2(0,180); 
        }
        if (moveHorizontal == 0f)
        {
           animator.SetFloat("Speed", 0); 
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 15f;
            animator.SetFloat("Speed", 2);
        }
        else
        {
            moveSpeed =10f;
        }
        #endregion

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
