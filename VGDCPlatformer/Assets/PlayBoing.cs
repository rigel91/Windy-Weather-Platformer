using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBoing : MonoBehaviour
{
    private AudioSource boingsound;
	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 0)
        {
            boingsound = GetComponent<AudioSource>();
            boingsound.Play();
        }
    }
}
