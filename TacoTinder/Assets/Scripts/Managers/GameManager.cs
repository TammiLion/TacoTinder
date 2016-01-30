using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private static GameManager mManager = null;

	public ArrayList players;
	public const int MAX_PLAYERS = 4;
	public GameObject playerPrefab;

	protected GameManager() {
		players = new ArrayList();
	}

	public static GameManager getInstance() {
		if (mManager == null) {
			mManager = new GameManager();
		}
		return mManager;
	}

	void Awake() {
		DontDestroyOnLoad (this);
	}

	void Start() {
		ControllerManager controllerManager = gameObject.AddComponent<ControllerManager>();
		controllerManager.onCharacterSelectionScreen ();
	}

	public GameObject onControllerAvailable() {
		GameObject player = (GameObject) Instantiate (playerPrefab, playerPrefab.transform.position, Quaternion.identity);
		players.Add (player);
		if (players.Count >= MAX_PLAYERS) {
			gameObject.GetComponent<ControllerManager>().onAllPlayersHaveControllersAssigned();
		}
		return player;
	}
	
}
