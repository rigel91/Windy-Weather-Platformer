using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class DeathMenu : MonoBehaviour {

    public Text scoreText;
    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
     
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
