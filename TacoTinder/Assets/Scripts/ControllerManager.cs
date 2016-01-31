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
			//Debug.Log("numControllers: " + numControllers);
			assignControllers();
		} else if (state == STATE_SELECTING) {
			assignAbilityButtons();
		}
	}

	private void assignAbilityButtons() {
		ControllerData controllerData = checkButtonPressedController ();
		if (controllerData == null) {
			return;
		}

		if (isControllerExtisting (controllerData.id) && isAbilityButtonNotFireButton (controllerData.id, controllerData.selectedButton)) {
			gameObject.GetComponent<GameManager>().onAbilityButtonAvailable (controllerData.id, controllerData.selectedButton);
			Debug.Log ("Controller " + controllerData.id + " has been assigned an Ability button.");
		}
	}

	private bool isControllerExtisting(int id) {
		foreach(ControllerData controller in controllers) {
			if(id == controller.id) {
				return true;
			}
		}
		return false;
	}

	private bool isAbilityButtonNotFireButton(int id, string selectedButton) {
		foreach(ControllerData controller in controllers) {
			if(id == controller.id &! (controller.selectedButton == selectedButton)) {
				return true;
			}
		}
		return false;
	}

	private void assignControllers() {
		ControllerData controllerData = checkButtonPressedController ();
		if (controllerData == null) {
			return;
		}
		for(int i = 0; i<controllers.Count; i++) {
				if(((ControllerData)controllers[i]).id == controllerData.id) {
					return;
				}
			}
		controllers.Add (controllerData);
		GameObject player = gameObject.GetComponent<GameManager>().onControllerAvailable ();
		player.GetComponent<Controller> ().id = controllerData.id;
		player.GetComponent<Controller> ().fireButton = controllerData.selectedButton;
		Debug.Log ("Player " + player.GetComponent<Player>().playerID + " has been assigned controller " + controllerData.id);
	}

	private ControllerData checkButtonPressedController() {
		for (int i = 0; i<20; i++) {
			for (int j = 1; j<numControllers+1; j++) {
				if (Input.GetKeyDown ("joystick " + j + " button " + i)) {
//					Debug.Log ("joystick " + j + " button " + i);
					return new ControllerData(j, "joystick " + j + " button " + i);
				}
			}
		}
		return null;
	}

	public void onAllPlayersHaveControllersAssigned() {
		state = STATE_SELECTING;
	}

	public void onAllPlayersHaveAbilityButtonsAssigned() {
		state = STATE_WAITING;
	}

	public void onCharacterSelectionScreen() {
		controllers = new ArrayList();
		state = STATE_ASSIGNING;
	}

	private class ControllerData {

		public int id;
		public string selectedButton;

		public ControllerData(int id, string firebutton) {
			this.id = id;
			this.selectedButton = firebutton;
		}

	}
}
