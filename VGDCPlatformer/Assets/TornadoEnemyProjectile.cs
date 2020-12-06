using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoEnemyProjectile : MonoBehaviour
{
    public int tornadoduration = 5;
    //private EnemyMoving EnemyMovingScript;
    //public string ObjectName;
    //private GameObject Snail;

    // Use this for initialization
    void Start()
    {
        //Snail = GameObject.Find(ObjectName);
       // EnemyMovingScript = Snail.gameObject.GetComponent<EnemyMoving>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, tornadoduration);
    }

    /*private void OnDestroy()
    {
        Snail.GetComponent<EnemyMoving>().stopMove = false;
    }*/
}
