using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int playerID;

	public float baseFireCooldown;
	public float baseRotationSpeed;
	public God god;
	public Weapon weapon;
	public Vector2 direction; // Maybe this should be private?
	public Vector2 targetDirection; // This too.

	// Temporary
	public GameObject tempProjectile;

	private float cooldownTimeStamp;

	// Use this for initialization
	void Start () {
		weapon.projectile.GetComponent<Projectile> ().player = this;
	}

	public void Move(float horizontal, float vertical) {
		targetDirection = new Vector2 (horizontal, vertical);
	}

	public void Fire () {
		// Don't fire when the cooldown is still active.
		if (this.cooldownTimeStamp >= Time.time) {
			return;
		}

		// Fire the weapon.
		this.weapon.FireWeapon (this.direction);

		// Set the cooldown.
		this.cooldownTimeStamp = Time.time + this.baseFireCooldown * this.weapon.fireCooldownModifier;
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Vector2.Angle (direction, targetDirection);
		this.transform.rotation = Quaternion.AngleAxis (angle, Vector3.up);
//		this.transform.Rotate (targetDirection.x, angle * baseRotationSpeed * Time.deltaTime);
		this.direction = new Vector2 (this.transform.forward.normalized.x, this.transform.forward.normalized.y);
	}

	public Vector2 getPosition() {
		return new Vector2(transform.position.x, transform.position.y);
	}
}
