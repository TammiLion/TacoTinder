using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {

	private static GameManager mManager = null;

	public ArrayList players;
	public int MAX_PLAYERS = 4;
	public GameObject playerPrefab;
	public Vector2[] spawnPositions;
	public UnityEngine.UI.Text instructionsText;
	public int WIN_POINTS = 200;

	private int abilityButtonsAssigned = 0;

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
		ControllerManager controllerManager = gameObject.AddComponent<ControllerManager>();
		controllerManager.onCharacterSelectionScreen ();
	}

	private void startTutorialRound() {
		instructionsText.gameObject.SetActive (false);
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
			onAllPlayersAreAssigned();
		}
		return player;
	}

	private void onAllPlayersAreAssigned() {
		instructionsText.text = "Now select the button that you would like to use for \"Ability\"";
	}

	private void onAllPlayersHaveAbilityButtons() {
		instructionsText.text = "A tutorial round will now start. " +
			"Shoot the mobs to get them to walk to your base and earn points. " +
			"Avoid the red mobs, they will make you lose points. " +
			"Mobs of your afiliation are worth extra points. " +
			"The bigger the mob the more points it's worth (or the more points it will cost)." +
				"You can shoot a mob that has already been shot. Each time it switches it will become worth more points.";

		Invoke ("startTutorialRound", 20f);
	}

	public void onAbilityButtonAvailable(int id, string abilityButton) {
		foreach (GameObject player in players) {
			if(player.GetComponent<Controller>().id == id) {
				player.GetComponent<Controller>().abilityButton = abilityButton;
				abilityButtonsAssigned++;
			}
		}
		if (abilityButtonsAssigned >= MAX_PLAYERS) {
			GetComponent<ControllerManager>().onAllPlayersHaveAbilityButtonsAssigned();
			onAllPlayersHaveAbilityButtons();
		}
	}
	
	public void onTutorialRoundEnded() {
		reset ();
		startGameRound ();
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
	private void startGameRound() {
		instructionsText.gameObject.SetActive (true);
		instructionsText.text = "The game will now start. The first player to reach " + WIN_POINTS + " wins";
		//GetComponent<RoundManager> ().time = 5;
		//GetComponent<RoundManager> ().start = true;
		Invoke ("startVersus", 4f);
	}

	private void startVersus() {
		instructionsText.gameObject.SetActive (false);
		// False since the round is not timed.
		GetComponent<SpawnManager> ().startSpawning (false);
	}
	
}
