using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBeginner : MonoBehaviour {

    public Rigidbody2D m_RigidBody2D;

    [Header("Movement Logic")]
    //=========== Moving Logic ============
    public float runSpeed = 0f;
    private float horizontalMove = 0f;
    //private Vector3 m_Velocity;
    public bool isMoving;

    [Space]
    [Header("Jump Logic")]

    //============ Jump Logic ============
    public float m_JumpForce = 200f;
    private bool m_Grounded;
    public Transform m_GroundCheck;
    public LayerMask m_GroundLayer;
    private int extraJumps;
    public int extraJumpsValue;


    // Use this for initialization
    void Start()
    {
        //m_RigidBody2D = GetComponent<Rigidbody2D>(); //Instead of manually putting the RigidBody2D Component we can get the component from the Object
        extraJumps = extraJumpsValue;
        //m_Velocity = Vector3.zero; //same as new Vector3(0,0,0)
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (m_Grounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
            --extraJumps;
        } else if (Input.GetButton("Jump") && extraJumps == 0 && m_Grounded)
        {
            m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
            m_Grounded = false;
        }


    }

    // FixedUpdate is called multiple times per frame at different rates
    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * runSpeed * 10f * Time.fixedDeltaTime, m_RigidBody2D.velocity.y);
        m_RigidBody2D.velocity = targetVelocity;
        if (horizontalMove == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        

        m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
    }

    public void multSpeed(float mul)
    {
        Debug.Log("yes");
        runSpeed = runSpeed * mul;
    }

}
