using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	//Controller 1 to 4
	public int id = 1;
	public Player player;

	public const string PREFIX_JOYSTICK = "Joystick "; 

	public Controller(int id, Player player) {
		this.id = id;
		this.player = player;
	}

	// Update is called once per frame
	void Update () {
		/*if (player == null) {
			return;
		}*/
		checkXAxis ();
		checkAButton ();
	}

	private void checkXAxis() {
		float value = Input.GetAxisRaw (PREFIX_JOYSTICK + id + " X axis");
		Debug.Log(PREFIX_JOYSTICK + id + " X axis: " + value);
		if (value != 0) {
			//player.moveAim(value);
		}
	}

	private void checkAButton() {
		if (Input.GetButtonDown (PREFIX_JOYSTICK + id + " A button")) {
			Debug.Log(PREFIX_JOYSTICK + id + " A button: " + true);
			//player.shoot(valueAButton);
		}
	}
}
