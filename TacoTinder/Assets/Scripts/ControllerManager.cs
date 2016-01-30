using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerManager : MonoBehaviour {

	private static ControllerManager mManager = null;
	private int numControllers;

	public const int STATE_ASSIGNING = 0;
	public const int STATE_SELECTING = 1;
	public const int STATE_WAITING = 2;

	private int state = STATE_WAITING;
	private ArrayList controllers;

	public const string CHARACTER_SELECTION_SCENE_NAME = "CharacterSelectionMenu";

	protected ControllerManager() {
		controllers = new ArrayList();
	}

	public static ControllerManager getInstance() {
		if (mManager == null) {
			mManager = new ControllerManager();
		}
		return mManager;
	}

	void Awake() {
		DontDestroyOnLoad (this);
	}

	// Update is called once per frame
	void Update () {
		if (state == STATE_WAITING) {
			return;
		} else if (state == STATE_ASSIGNING) {
			numControllers = Input.GetJoystickNames ().Length;
			Debug.Log("numControllers: " + numControllers);
			assignControllers();
		} else if (state == STATE_SELECTING) {
		}
	}

	private void assignControllers() {
		ControllerData controller = checkFireButtonPressedController ();
		if (controller == null) {
			return;
		}
		for(int i = 0; i<controllers.Count; i++) {
				if(((ControllerData)controllers[i]).id == controller.id) {
					return;
				}
			}
		controllers.Add (controller);
		GameObject player = gameObject.GetComponent<GameManager>().onControllerAvailable ();
		player.GetComponent<Controller> ().id = controller.id;
		player.GetComponent<Controller> ().fireButton = controller.fireButton;
		Debug.Log ("Player " + player.GetComponent<Player>().playerID + " has been assigned controller " + controller.id);
	}

	private ControllerData checkFireButtonPressedController() {
		for (int i = 0; i<20; i++) {
			for (int j = 1; j<numControllers+1; j++) {
				if (Input.GetKeyDown ("joystick " + j + " button " + i)) {
					Debug.Log ("joystick " + j + " button " + i);
					return new ControllerData(j, "joystick " + j + " button " + i);
				}
			}
		}
		return null;
	}

	public void onAllPlayersHaveControllersAssigned() {
		if (state == STATE_ASSIGNING && Application.loadedLevelName.Contains(CHARACTER_SELECTION_SCENE_NAME)) {
			state = STATE_SELECTING;
		} else {
			state = STATE_WAITING;
		}
	}

	public void onCharacterSelectionScreen() {
		controllers = new ArrayList();
		state = STATE_ASSIGNING;
	}

	private class ControllerData {

		public int id;
		public string fireButton;

		public ControllerData(int id, string firebutton) {
			this.id = id;
			this.fireButton = firebutton;
		}

	}
}
