using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	public Vector2 direction;
	public float speed;
	
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = transform.TransformDirection(direction.normalized*speed);
	}
}
