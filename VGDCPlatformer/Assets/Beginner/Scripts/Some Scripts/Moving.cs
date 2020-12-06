using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    //private BoxCollider2D PlayerBox;
    //private Vector3 m_Velocity;//stores speed of char
    public Rigidbody2D m_RigidBody2D;
    public float RunSpeed = 15f;//changes speed
    public float HorizontalMove = 0f;//this is the speed
    public float m_JumpForce = 200f;
    public Animator anim;
    private SpriteRenderer sr;
    public LayerMask GroundLayer;
    public bool FaceRight;
    public int numJumps;
    private bool isGrounded;
    private AudioSource jumpSound;
    //=======================Dashing==================
    //variables for dashing, you can set the time for how long the dash will last and how far
    private int direction;
    private float dashTime;
    public float startDashTime;
    public float dashForce;
    public bool isDashing;
    public float HorizontalInput;

    public SceneManagement pauseInteraction;

    // Use this for initialization
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
        FaceRight = true;
        //PlayerBox = GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //m_Velocity = Vector3.zero;

        //================== Dashing =============
        isDashing = false;
        //this sets the time for how long the player will dash
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        if (HorizontalInput != 0)
        {
            //This flips the player model depending on the direction they are going
            if (HorizontalInput == 1)
            {
                sr.flipX = false;
                FaceRight = true;
            }
            else
            {
                sr.flipX = true;
                FaceRight = false;
            }
            HorizontalMove = HorizontalInput * RunSpeed;
            //This causes the running animation to play
            anim.SetBool("running", true);
        }
        else
        {
            //This causes the running animation to stop
            anim.SetBool("running", false);
            //This removes all momentum
            HorizontalMove = 0;
        }

        if (m_RigidBody2D.velocity.y != 0)
        {
            //This causes the jumping animation to play
            anim.SetBool("jumping", true);
        }

        if (!pauseInteraction.stopThingsWhenPaused)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //Double jump works by having a variable that counts down everytime the player jumps. 
                //If you have a better method, go ahead and implement it.
                //Ground check via raycast
                if (isGrounded)
                {
                    //anim.SetBool("jumping", true);
                    jumpSound.Play();
                    m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 0);
                    m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
                }
                else if (/*IsGrounded()*/numJumps > 0)
                {
                    anim.SetBool("jumping", true);
                    jumpSound.Play();
                    m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 0);
                    m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce * 3 / 4));
                    numJumps -= 1;
                }
            }
            else if (isGrounded)
            {
                //This causes the jumping animation to stop
                anim.SetBool("jumping", false);
                numJumps = 1;
            }
        }
        
    }
    void FixedUpdate()
    {
        //sets the movement of character
        Vector3 targetVelocity = new Vector2(HorizontalMove * RunSpeed * Time.fixedDeltaTime, m_RigidBody2D.velocity.y);
        m_RigidBody2D.velocity = targetVelocity;
        // Debug.Log(m_RigidBody2D.velocity);

        /*
        //======================= Dashing ==========================
        //this checks if the player is facing right or left
        //if facing right, then direction is +1 in x direction
        //if facing left(not right), then direction is -1 in x direction
        if (FaceRight)
        {
            direction = 1;
        }
        else if (!FaceRight)
        {
            direction = -1;
        }

        //if the player presses V, then dash
        if (Input.GetKeyDown(KeyCode.V))
        {
            isDashing = true;
        }

        //if the player is dashing then dash
        if (isDashing)
        {
            //this tells us how ling the dash is lasting for
            //and resets the timer when the dashTime is below 0
            if (dashTime <= 0)
            {
                dashTime = startDashTime;
                isDashing = false;
                m_RigidBody2D.velocity = Vector2.zero;
            }
            else
            {
                //continually add force whichever direction is facing
                m_RigidBody2D.velocity = new Vector2(dashForce * direction, m_RigidBody2D.velocity.y);
                dashTime -= Time.deltaTime;

            }
        }*/
    }

    /*bool IsGrounded()
    {
        //Uses the boundaries of the player box collider to spawn the ray start locations'''
        Vector2 StartPosition1 = PlayerBox.bounds.center - PlayerBox.bounds.extents;
        Vector2 StartPosition2 = PlayerBox.bounds.center + new Vector3(PlayerBox.bounds.extents.x, -PlayerBox.bounds.extents.y, 0);
            //Vector2 StartPosition1 = new Vector2 (LeftBound.x, LeftBound.y);
            //Vector2 StartPosition2 = new Vector2 (RightBound.x, RightBound.y);
        Vector2 Direction = Vector2.down;
        //Distance of ray
        float Distance = .15f;
        Debug.DrawRay(StartPosition1, Distance * Direction, Color.red);
        Debug.DrawRay(StartPosition2, Distance * Direction, Color.red);
        //Checks to see if it collided with an object in the ground layer
        RaycastHit2D hitground1 = Physics2D.Raycast(StartPosition1, Direction, Distance, GroundLayer);
        RaycastHit2D hitground2 = Physics2D.Raycast(StartPosition2, Direction, Distance, GroundLayer);
            //Debug.Log(hitground1.collider.name);
        //if it is colliding with something, returns true
        if (hitground1.collider || hitground2.collider != null)
        {
         //   Debug.Log(hitground1.collider.name);
            return true;
        }
        return false;
    }
    */


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            isGrounded = true;
        }
        else
            isGrounded = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
}
