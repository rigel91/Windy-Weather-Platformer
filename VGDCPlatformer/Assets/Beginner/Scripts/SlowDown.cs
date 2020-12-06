using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour {

    public PlayerMovementBeginner other;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        other.multSpeed(.25f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        other.multSpeed(4f);
    }
}
