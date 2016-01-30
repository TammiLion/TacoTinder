using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Projectile") {
			// Destroy the arrow since it's out of bounds.
			Destroy (other.gameObject);
		} else if (other.tag == "Mob") {
			// Turn the mob around for now.
			Moveable mobMoveable = other.GetComponent<Moveable> ();
			Vector2 mobDirection = mobMoveable.direction;
			// Inverse the direction of the mob.
			mobMoveable.direction = new Vector2 (-1 * mobDirection.x, -1 * mobDirection.y);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

