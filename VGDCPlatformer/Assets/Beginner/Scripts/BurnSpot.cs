using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnSpot : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D other_rb = collision.GetComponent<Rigidbody2D>();
        other_rb.AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
        other_rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }
}
