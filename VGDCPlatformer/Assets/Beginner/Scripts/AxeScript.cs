using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {
	public GameObject ThrownAxe;
	private BoxCollider2D hitbox;
	public Rigidbody2D rb;


	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "floor" || other.gameObject.tag == "hurtbox" )
        {


        }
        if (other.gameObject.tag == "floor" || other.gameObject.tag == "hurtbox")
        {
            Destroy(gameObject);
        }
    }

	private void OnBecomeInvisible()
	{
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
