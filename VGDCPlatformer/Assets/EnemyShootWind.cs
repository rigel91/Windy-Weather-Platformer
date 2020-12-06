using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootWind : MonoBehaviour
{
    public GameObject ThrowingWeapon;
    public EnemyMoving movingright;
    //private Vector2 Face;
    private Vector3 StartLocation;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (movingright.MovingRight == true)
            {
                movingright.stopMove = true;
                //Face = Vector2.right;
                StartLocation = new Vector3(transform.position.x + 5f, transform.position.y, 0);
                Instantiate(ThrowingWeapon, StartLocation, Quaternion.identity);
                // GameObject projectile2 = Instantiate(ThrowingWeapon2, StartLocation, Quaternion.identity);
                //projectile.transform.Translate(new Vector2(20, 0));
            }
            if (movingright.MovingRight != true)
            {
                movingright.stopMove = true;
                //Face = Vector2.left;
                StartLocation = new Vector3(transform.position.x - 5f, transform.position.y, 0);
                Instantiate(ThrowingWeapon, StartLocation, Quaternion.identity);
                //sr = projectile.GetComponent<SpriteRenderer>();
                //sr.flipX = true;
                //projectile.transform.Translate(new Vector2(-20, 0));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(movingright.stopMove == true)
        {
            movingright.stopMove = false;
        }
    }
}
