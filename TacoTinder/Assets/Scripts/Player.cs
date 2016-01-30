using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float baseCooldown;
	public float baseSpeed;
	public God god;
	public Vector2 direction;
//	public Weapon weapon;

	private float cooldownTimeStamp;

	// Use this for initialization
	void Start () {
		
	}

	void Fire () {
		// Don't fire when the cooldown is still active.
		if (this.cooldownTimeStamp >= Time.time) {
			return;
		}

		// Fire the weapon.
		// TODO

		// Set the cooldown.
		this.cooldownTimeStamp = Time.time + this.baseCooldown;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
