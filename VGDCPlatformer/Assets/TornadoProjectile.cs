using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoProjectile : MonoBehaviour {
    private ThrowWeapon Throwscript;
    private GameObject Player;
    public string ObjectName;
    public int tornadoduration;
    public GameObject tornado;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find(ObjectName);
        Throwscript = Player.gameObject.GetComponent<ThrowWeapon>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(gameObject, tornadoduration);
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Throwscript.tornadocount -= 1;
    }
}
