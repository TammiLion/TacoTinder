using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public Player player;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Mob") {
			// DO STUFF.
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
