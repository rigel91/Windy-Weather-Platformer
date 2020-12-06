using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
 //   private BoxCollider2D PlayerBox;
  /*  private Vector3 m_Velocity;//stores speed of char
 */ public Rigidbody2D m_RigidBody2D;
    public float RunSpeed = 15f;//changes speed 
    public float HorizontalMove = 0f;//this is the speed
 //   public float m_JumpForce = 200f;
    //========================================
    public Animator anim;
    //private SpriteRenderer sr;
    public LayerMask GroundLayer; 
    //========================================
    //private bool inBounds;
    public Transform leftBound;
    public Transform rightBound;
    private int count;
    public int FrameMovement;
    private Vector2 MoveRight;
    private Vector2 MoveLeft;
    public bool MovingRight = true;
    public bool MovingLeft = false;
    private Vector2 localScale;
    private float leftflip;
    private float rightflip;
    public bool stopMove = false;
    private AudioSource bounceSound;


    // Use this for initialization
    void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
        //sr = GetComponent<SpriteRenderer>();
          //m_Velocity = Vector3.zero;
        localScale = gameObject.transform.localScale;
        rightflip = -localScale.x;
        leftflip = localScale.x;
        //MoveLeft = new Vector2(-HorizontalMove, m_RigidBody2D.velocity.y);
        //MoveRight = new Vector2(HorizontalMove, m_RigidBody2D.velocity.y); 
        m_RigidBody2D.velocity = MoveLeft;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        MoveLeft = new Vector2(-HorizontalMove, m_RigidBody2D.velocity.y);
        MoveRight = new Vector2(HorizontalMove, m_RigidBody2D.velocity.y);
        //Debug.Log(transform.position.x > leftBound.position.x);
        if (transform.position.x < leftBound.position.x)
        {
            //m_RigidBody2D.velocity = new Vector2(0, m_RigidBody2D.velocity.y);
            flipRight();
            //print("moving left = " + MovingLeft);
            //print("moving right = " + MovingRight);
        }
        else if (transform.position.x > rightBound.position.x)
        {
            //m_RigidBody2D.velocity = new Vector2(0, m_RigidBody2D.velocity.y);
            flipLeft();
            //print("this happened");
            //print("moving left = " + MovingLeft);
            //print("moving right = " + MovingRight);
        }
        if (stopMove == true)
        {
            m_RigidBody2D.velocity = new Vector2(0, m_RigidBody2D.velocity.y);
            anim.SetBool("Is Moving", false);
        }
        else if (stopMove == false && MovingRight == true)
        {
            m_RigidBody2D.velocity = MoveRight;
            anim.SetBool("Is Moving", true);
        }
        else if (stopMove == false && MovingLeft == true)
        {
            m_RigidBody2D.velocity = MoveLeft;
            anim.SetBool("Is Moving", true);
        }
    }
    private void flipRight()
    {
        MovingRight = true;
        MovingLeft = false;
        localScale.x = rightflip;
        transform.localScale = localScale;
    }

    private void flipLeft()
    {
        MovingLeft = true;
        MovingRight = false;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x = leftflip;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            bounceSound = GetComponent<AudioSource>();
            bounceSound.Play();
        }
    }
}
