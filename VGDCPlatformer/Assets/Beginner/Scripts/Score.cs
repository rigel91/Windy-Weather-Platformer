using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public Text timer;
    public float timerCount;
    public float pointsPerSecond;

    // Update is called once per frame
    void Update () {

        if (timerCount >= 1)
        {
            timerCount -= pointsPerSecond * Time.deltaTime; 
        } else
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        string minutes = Mathf.Floor(timerCount / 60).ToString("00");
        string seconds = Mathf.Floor(timerCount % 60).ToString("00");


        timer.text = "Time: " + string.Format("{0}:{1}", minutes, seconds);
	}
}
