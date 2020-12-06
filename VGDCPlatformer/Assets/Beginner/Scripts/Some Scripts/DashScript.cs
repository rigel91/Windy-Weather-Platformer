using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{

    //for dashing physics
    private Rigidbody2D rb;

    //gets access to the player script to see if the player is facing right or not
    public Moving thePlayer;

    //variables for dashing, you can set the time for how long the dash will last and how far
    private int direction;
    private float dashTime;
    public float startDashTime;
    public float dashForce;
    public bool isDashing;
    

    // Use this for initialization
    void Start()
    {
        //the starting direction since the player is facing right when game starts
        direction = 1;
        //the player is not dashing when game starts
        isDashing = false;
        //this sets the time for how long the player will dash
        dashTime = startDashTime;
        //gets rigidbody component of whatever this script is attached too
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   

    }

    void FixedUpdate()
    {
        Invoke("_fixedUpdate", 1f);
    }
    void _fixedUpdate()
    {
        //this checks if the player is facing right or left
        //if facing right, then direction is +1 in x direction
        //if facing left(not right), then direction is -1 in x direction
        if (thePlayer.FaceRight)
        {
            direction = 1;
        }
        else if (!thePlayer.FaceRight)
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
                rb.velocity = Vector2.zero;
            }
            else
            {
                //continually add force whichever direction is facing
                rb.velocity = new Vector2(dashForce * direction, rb.velocity.y);
                dashTime -= Time.deltaTime;

            }
        }

    }

}
