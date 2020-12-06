using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafProjectile : MonoBehaviour
{
    //private Rigidbody2D WeaponRigidBody;
    //private GameObject leaf;
    //private BoxCollider2D hitbox;
    //public float speed;
    //public Moving PlayerMovingScript;
    //public Vector2 Direction;
    private Health HealthScript;
    // Use this for initialization
    void Start()
    {
        
        //WeaponRigidBody = GetComponent<Rigidbody2D>();
        //leaf = GetComponent<GameObject>();
        //hitbox = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hitbox")
        {
            try
            {
                Health hp = other.gameObject.GetComponent<Health>();
                hp.HP -= 20;
            }
            catch
            {

            }
        }
        //Debug.Log("k"); //Just for debugging
        if (other.gameObject.tag == "floor" /* || other.gameObject.tag != "Gizmos" */|| other.gameObject.tag == "hurtbox")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
