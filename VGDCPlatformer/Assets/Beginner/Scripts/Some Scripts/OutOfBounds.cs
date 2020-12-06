using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public float OoB;
    public GameObject RespawnPointx;
    public Health HealthScript;
    //Health health = Player.GetComponent<Health>();
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (transform.position.y < OoB)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            //transform.position = RespawnPointx.transform.position;
            //HealthScript.HP -= 20;
        }
    }
}
