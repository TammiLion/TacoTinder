using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public Sprite[] projectileSprites;
	public Player player;
	// Use this for initialization
	void Start () {

	}

	public void setPlayer (Player player) {
		this.player = player;
		this.GetComponent<SpriteRenderer> ().sprite = projectileSprites [player.playerID - 1];
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Mob") {
			if (other.GetComponent<Mob> ().getHit (player)) {
				Destroy (this.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
