using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public EnemyMoving Direction;
    public LayerMask P_Layer;
    //private CircleCollider2D Enemy;
    //private Vector2 Face;
    private Vector3 StartLocation;
    public GameObject ThrowingWeapon;
    public GameObject ThrowingWeapon2;
    private SpriteRenderer sr;
    public float Limit;
    private float projectileLimit = 0;
    
    // Use this for initialization
    void Start ()
    {
        //Enemy = GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /* if (Direction.moveRight)
         {
             Face = Vector2.right;
             if (PlayerSpotted())
             {
                 StartLocation = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                 GameObject projectile = Instantiate(ThrowingWeapon1, StartLocation, Quaternion.identity);
                 projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
             }
         }
         else
         {
             Face = Vector2.left;
             if (PlayerSpotted())
             {
                 StartLocation = new Vector3(transform.position.x - .7f, transform.position.y, 0);
                 GameObject projectile = Instantiate(ThrowingWeapon1, StartLocation, Quaternion.identity);
                 sr = projectile.GetComponent<SpriteRenderer>();
                 sr.flipX = true;
                 projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
             }
         }*/
        //print(Direction.moveRight);
	}

    /* bool PlayerSpotted()
     {
         Vector2 StartPosition = Enemy.bounds.center;
         float Distance = 2f;        
         Debug.DrawRay(StartPosition, Distance * Face, Color.red);
         RaycastHit2D SeePlayer = Physics2D.Raycast(StartPosition, Face, Distance, P_Layer);
         if (SeePlayer.collider != null)
         {
             //   Debug.Log(hitground1.collider.name);
             return true;
         }
         return false;
     }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            projectileLimit = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Direction.MovingRight == true)
            {
                //Face = Vector2.right;
                StartLocation = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                if (projectileLimit < Limit)
                {
                    GameObject projectile = Instantiate(ThrowingWeapon, StartLocation, Quaternion.identity);
                    projectileLimit++;
                    // GameObject projectile2 = Instantiate(ThrowingWeapon2, StartLocation, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
                }
               // projectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
            }
            else if(Direction.MovingLeft == true)
            {
                //Face = Vector2.left;
                StartLocation = new Vector3(transform.position.x - .7f, transform.position.y, 0);
                if (projectileLimit < Limit)
                {
                    GameObject projectile = Instantiate(ThrowingWeapon, StartLocation, Quaternion.identity);
                    projectileLimit++;
                    sr = projectile.GetComponent<SpriteRenderer>();
                    sr.flipX = true;
                    projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
                }
                //GameObject projectile2 = Instantiate(ThrowingWeapon2, StartLocation, Quaternion.identity);
                
               // projectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
            }
        }
    }
}
