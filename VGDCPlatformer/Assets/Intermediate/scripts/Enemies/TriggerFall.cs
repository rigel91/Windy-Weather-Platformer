using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    public float destroyTime = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if this gameObject detects the player 
        //gameObject will drop down by gravity
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = gameObject.GetComponentInChildren<Rigidbody2D>();
            //Debug.Log(rb.name);
            rb.isKinematic = false; //changing Body Type to Dynamic to allow gravity
            Destroy(gameObject, destroyTime);
        }
    }
}
