using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	private AudioSource audio;
	public AudioClip musicLoop;
	
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying &! musicLoop == null) {
			audio.clip = musicLoop;
			audio.loop = true;
			audio.Play();
		}
	}
}
