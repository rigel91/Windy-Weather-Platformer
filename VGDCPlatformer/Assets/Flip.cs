using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public TheEnemy Flp;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("k");
        if (other.gameObject.tag == "hurtbox")
        {
            Flp.Flip();
            //print("k");
        }
    }
}
