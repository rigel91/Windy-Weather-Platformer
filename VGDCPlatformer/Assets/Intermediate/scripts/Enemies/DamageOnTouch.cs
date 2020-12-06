using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public GameObject fullIcicle;
    public GameObject dangerzone;
    private AudioSource freezeSound;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //This should work, but it really doesnt.
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (!rb.isKinematic)
        {
            if (other.gameObject.tag == "floor")
            {
                Destroy(dangerzone);
            }
            //if this object touches an enemy's hurtbox
            if (other.gameObject.tag == "Player")
            {
                try
                {
                    other.GetComponent<Freeze>().StartCoroutine("Frozen");
                }
                catch
                {

                }
            }
        }
        if (other.gameObject.tag == "Player")
        {
            try
            {
                freezeSound = fullIcicle.GetComponent<AudioSource>();
                freezeSound.Play();
                other.GetComponent<Freeze>().StartCoroutine("Frozen");

            }
            catch
            {

            }
        }
    }
}
