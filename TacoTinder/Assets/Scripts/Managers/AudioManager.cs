using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip secondSound;
	public AudioClip timerSound;
	public AudioClip winnerSound;
	public AudioClip fattySound;

	public AudioClip[] followerEnteredSounds;
	
	AudioSource audio;
	
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		
		GameObject manager = GameObject.Find ("Manager");
		GameManager gameManagerScript = (GameManager) manager.GetComponent<GameManager> ();
		gameManagerScript.onWinner += this.handleOnWinnerEvent;

		SpawnManager spawnScript = manager.GetComponent<SpawnManager> ();
		spawnScript.onFatty += this.handleOnFattyEvent;

		RoundManager roundManagerScript = (RoundManager) manager.GetComponent<RoundManager> ();
		roundManagerScript.onSecondSound += this.handleOnSecondSoundEvent;
		roundManagerScript.onTimerEndedSound += this.handleOnTimerEndedSound;

		GameObject inca = GameObject.Find ("inca");
		GameObject japan = GameObject.Find ("japan");
		GameObject pyramid = GameObject.Find ("pyramid");
		GameObject aquaman = GameObject.Find ("aquaman");
		inca.GetComponent<Base> ().onEnterBase += this.handleOnFollowerEnteredBaseEvent;
		japan.GetComponent<Base> ().onEnterBase += this.handleOnFollowerEnteredBaseEvent;
		pyramid.GetComponent<Base> ().onEnterBase += this.handleOnFollowerEnteredBaseEvent;
		aquaman.GetComponent<Base> ().onEnterBase += this.handleOnFollowerEnteredBaseEvent;
	}
	
	public void handleOnWinnerEvent(object sender, System.EventArgs args) {
		audio.PlayOneShot(winnerSound, 1F);
	}
	
	public void handleOnSecondSoundEvent(object sender, System.EventArgs args) {
		audio.PlayOneShot(secondSound, 0.5F);
	}
	
	public void handleOnTimerEndedSound(object sender, System.EventArgs args) {
		audio.PlayOneShot(timerSound, 1F);
	}

	public void handleOnFollowerEnteredBaseEvent(object sender, System.EventArgs args) {
		audio.PlayOneShot(followerEnteredSounds[Random.Range(0, followerEnteredSounds.Length)], 0.5F);
	}

	public void handleOnFattyEvent(object sender, System.EventArgs args) {
		audio.PlayOneShot (fattySound, 1F);
	}
}
