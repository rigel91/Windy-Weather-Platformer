using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour {

	// Use this for initialization
	public AudioClip MusicClip;
	public AudioSource MusicSource;
	void Start () {
		MusicSource.clip =  MusicClip;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!MusicSource.isPlaying){
			MusicSource.Play();
		}
	}
}
