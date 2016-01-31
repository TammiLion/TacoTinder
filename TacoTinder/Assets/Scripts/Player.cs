using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public int playerID;
	public Sprite[] arrowSprites;

	public float baseFireCooldown;
	public float baseRotationSpeed;
	public string god;
	public Weapon weapon;
	public Vector3 targetDirection; // This too.

	private float cooldownTimeStamp;
	private SpriteRenderer arrowSprite;

	// Use this for initialization
	void Start () {
		weapon.projectile.GetComponent<Projectile> ().player = this;
		// Set the sprite for this playerID.
		this.arrowSprite = this.GetComponent<SpriteRenderer> ();
		this.arrowSprite.sprite = arrowSprites[this.playerID - 1];
	}

	public void Move(float horizontal, float vertical) {
		targetDirection = new Vector3 (horizontal, vertical, 1).normalized;
	}

	public void Fire () {
		// Don't fire when the cooldown is still active.
		if (this.cooldownTimeStamp >= Time.time) {
			return;
		}

		// Fire the weapon.
		this.weapon.FireWeapon (this.transform.up * -1, this.getPosition(), this);

		// Set the cooldown.
		this.cooldownTimeStamp = Time.time + this.baseFireCooldown * this.weapon.fireCooldownModifier;
	}
	
	// Update is called once per frame
	void Update () {
		float step = baseRotationSpeed * Time.deltaTime;
		Vector3 newDirection = Vector3.RotateTowards (transform.forward, targetDirection, step, 0.0F);
		this.transform.rotation = Quaternion.Inverse(Quaternion.LookRotation (Vector3.forward, newDirection));

		// Update the cooldown timer (alpha of the sprite)
		if (this.cooldownTimeStamp >= Time.time) {
			float timeLeft = this.cooldownTimeStamp - Time.time;
			float percentage = timeLeft / (this.baseFireCooldown * this.weapon.fireCooldownModifier);
			this.arrowSprite.color = new Color(1f,1f,1f,1 - percentage);
		}

	}

	public Vector2 getPosition() {
		return new Vector2(transform.position.x, transform.position.y);
	}
}
