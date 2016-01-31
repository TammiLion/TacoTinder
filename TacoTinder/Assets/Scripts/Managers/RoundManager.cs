using UnityEngine;
using System.Collections;
using System;

public class RoundManager : MonoBehaviour {

	public UnityEngine.UI.Text timerText;
	public float time = 35;
	public bool start = false;
	private bool secondSoundActivated = false;

	public event EventHandler onSecondSound;
	public event EventHandler onTimerEndedSound;
	
	public void onSecondSoundEvent() {
		EventHandler handler = onSecondSound;
		if (handler != null) {
			handler(this, System.EventArgs.Empty);
		}
	}

	public void onTimerEndedSoundEvent() {
		EventHandler handler = onTimerEndedSound;
		if (handler != null) {
			handler(this, System.EventArgs.Empty);
		}
	}

	// Update is called once per frame
	void Update () {
		if (start) {
			checkForSecondSound();
			timerText.gameObject.SetActive(true);
			time -= Time.deltaTime;
			timerText.text = (int)time + "s";
			checkTimePassed ();
		}
	}

	private void checkForSecondSound() {
		if (!secondSoundActivated && time > 10f && time - Time.deltaTime < 10f) {
			secondSoundActivated = true;
			InvokeRepeating("playSecondSound", 0f, 1f);
		}
	}

	private void playSecondSound() {
		onSecondSoundEvent ();
	}

	private void checkTimePassed() {
		if (time < 1 && secondSoundActivated == true) {
			secondSoundActivated = false;
			CancelInvoke();
			onTimerEndedSoundEvent();
			GetComponent<GameManager>().onTutorialRoundEnded();
			start = false;
			timerText.gameObject.SetActive(false);
		}
	}
}
