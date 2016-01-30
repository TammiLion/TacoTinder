using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Player player;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Mob") {
			Debug.Log ("Hit a mob");
			other.GetComponent<Mob> ().getHit (player);
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
