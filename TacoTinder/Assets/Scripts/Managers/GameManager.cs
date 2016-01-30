using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private static GameManager mManager = null;

	public ArrayList players;
	public const int MAX_PLAYERS = 4;
	public GameObject playerPrefab;
	public Vector2[] spawnPositions;

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
		GetComponent<RoundManager> ().start = true;
		GetComponent<SpawnManager> ().startSpawning ();
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
			GameObject baseObject = GameObject.FindGameObjectWithTag(god);
			baseObject.GetComponent<Base>().points = 0;
		}
	}

	//After the tutorial round has passed
	private void showObjective() {
		GetComponent<RoundManager> ().time = 5;
		GetComponent<RoundManager> ().start = true;
		Invoke ("startVersus", 5f);
	}

	private void startVersus() {
		GetComponent<SpawnManager> ().startSpawning ();
	}
	
}
