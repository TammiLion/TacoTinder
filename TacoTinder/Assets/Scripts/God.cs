using UnityEngine;
using System.Collections;

public class God : MonoBehaviour
{
	public string godName;
	public static string[] GODS = { "aquaman", "pyramid", "inca", "japan", "neutral"};

	public int aquaCost = 10;
	public float aquaCooldown = 10;
	public int pyramidCost = 10;
	public float pyramidCooldown = 10;
	public int incaCost = 10;
	public float incaCooldown = 10;
	public int japanCost = 10;
	public float japanCooldown = 10;

	private float aquaTimestamp;
	private float pyramidTimestamp;
	private float incaTimestamp;
	private float japanTimestamp;

	public float fearIntervals = 0.7f;
	public float pyramidDuration = 3f;
	private float pyramidEnd;

	// Use this for initialization
	void Start ()
	{
	
	}

	public void activateSuper(string name, Base playerBase) {
		if (name == GODS [0]) {
			this.activateAqua (playerBase);
		} else if (name == GODS [1]) {
			this.activatePyramid (playerBase);
		} else if (name == GODS [2]) {
			this.activateInca (playerBase);
		} else if (name == GODS [3]) {
			this.activateJapan (playerBase);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Pyramid duration.
		if (pyramidEnd > Time.time)
		{
			Debug.Log("spook stop");
			CancelInvoke ();
			this.cancelFearMobs ();
		}
	}

	void activateAqua (Base playerBase) {
		if (playerBase.points < aquaCost) {
			return;
		}

		if (aquaTimestamp > Time.time) {
			return;
		}

		// Set cooldown.
		aquaTimestamp = Time.time + japanCooldown;
	}

	#region Pyramid
	void activatePyramid (Base playerBase) {
		if (playerBase.points < pyramidCost) {
			return;
		}

		if (pyramidTimestamp > Time.time) {
			return;
		}

		pyramidEnd = Time.time + pyramidDuration;
		InvokeRepeating("fearMobs", 0, fearIntervals);

		// Set cooldown.
		pyramidTimestamp = Time.time + japanCooldown;
	}

	void fearMobs () {
		GameObject[] mobs = GameObject.FindGameObjectsWithTag ("Mob");
		foreach (GameObject mob in mobs) {
			mob.GetComponent<Mob> ().fear ();
		}
	}

	void cancelFearMobs () {
		GameObject[] mobs = GameObject.FindGameObjectsWithTag ("Mob");
		foreach (GameObject mob in mobs) {
			mob.GetComponent<Mob> ().cancelFear ();
		}
	}
	#endregion

	void activateInca (Base playerBase) {
		if (playerBase.points < incaCost) {
			return;
		}

		if (incaTimestamp > Time.time) {
			return;
		}

		// Set cooldown.
		incaTimestamp = Time.time + japanCooldown;
	}

	void activateJapan (Base playerBase) {
		if (playerBase.points < japanCost) {
			return;
		}

		if (japanTimestamp > Time.time) {
			return;
		}

		// Set cooldown.
		japanTimestamp = Time.time + japanCooldown;
	}
}

