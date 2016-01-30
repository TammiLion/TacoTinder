using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float baseCooldown;
	public float baseSpeed;
	public God god;
	public Vector2 direction; // Maybe this should be private?
//	public Weapon weapon;

	private float cooldownTimeStamp;

	// Use this for initialization
	void Start () {
		
	}

	public void Move(float horizontal, float vertical) {
		Vector2 moveDirection = new Vector2 (horizontal, vertical);

	}

	public void Fire () {
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
