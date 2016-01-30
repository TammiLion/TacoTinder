using UnityEngine;
using System.Collections;

public class RoundManager : MonoBehaviour {

	public UnityEngine.UI.Text timerText;
	public float time = 35;
	public bool start = false;

	// Update is called once per frame
	void Update () {
		if (start) {
			timerText.gameObject.SetActive(true);
			time -= Time.deltaTime;
			timerText.text = (int)time + "s";
			checkTimePassed ();
		}
	}

	private void checkTimePassed() {
		if (time <= 0) {
			GetComponent<GameManager>().onRoundTimePassed();
			start = false;
			timerText.gameObject.SetActive(false);
		}
	}
}
