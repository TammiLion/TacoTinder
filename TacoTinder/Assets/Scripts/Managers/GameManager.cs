using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {

	private static GameManager mManager = null;

	public ArrayList players;
	public const int MAX_PLAYERS = 4;
	public GameObject playerPrefab;
	public Vector2[] spawnPositions;

	public event EventHandler onWinner;
	
	public void onWinnerEvent() {
		EventHandler handler = onWinner;
		if (handler != null) {
			handler(this, System.EventArgs.Empty);
		}
	}

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
		Debug.Log ("Start GameManager");
		ControllerManager controllerManager = gameObject.AddComponent<ControllerManager>();
		controllerManager.onCharacterSelectionScreen ();
		GetComponent<RoundManager> ().start = true;
		GetComponent<SpawnManager> ().startSpawning (true);
	}

	public GameObject onControllerAvailable() {
		GameObject player = (GameObject) Instantiate (playerPrefab, spawnPositions[players.Count], Quaternion.identity);
		player.GetComponent<Player>().god = God.GODS[players.Count];
		GameObject baseObject = GameObject.FindWithTag(God.GODS[players.Count]);
		baseObject.GetComponent<Base> ().player = player.GetComponent<Player>();
		players.Add (player);
		player.GetComponent<Player> ().playerID = players.Count;
		if (players.Count >= MAX_PLAYERS) {
			gameObject.GetComponent<ControllerManager>().onAllPlayersHaveControllersAssigned();
		}
		return player;
	}

	public void onRoundTimePassed() {
		reset ();
		showObjective ();
	}

	private void reset() {
		GetComponent<SpawnManager> ().stopSpawning ();
		foreach (GameObject mob in GameObject.FindGameObjectsWithTag("Mob")) {
			Destroy(mob);
		}
		foreach (string god in God.GODS) {
			if(god == God.GODS[4]) {
				break;
			}
			GameObject baseObject = GameObject.FindGameObjectWithTag(god);
			baseObject.GetComponent<Base>().points = 0;
			baseObject.GetComponent<Base>().setPoints();
		}
	}

	//After the tutorial round has passed
	private void showObjective() {
		//GetComponent<RoundManager> ().time = 5;
		//GetComponent<RoundManager> ().start = true;
		Invoke ("startVersus", 4f);
	}

	private void startVersus() {
		// False since the round is not timed.
		GetComponent<SpawnManager> ().startSpawning (false);
	}
	
}
