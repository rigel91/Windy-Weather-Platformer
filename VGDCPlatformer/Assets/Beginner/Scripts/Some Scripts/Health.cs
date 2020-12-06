using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float HP;
    public Rigidbody2D ObjectRigidBody;
    //public BoxCollider2D ObjectCollider;
	// Use this for initialization
	void Start ()
    {
        //ObjectRigidBody = gameObject.GetComponent<Rigidbody2D>();
        //ObjectCollider = gameObject.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
           // Destroy(ObjectRigidBody);
           // Destroy(ObjectCollider);
        }
    }
}
