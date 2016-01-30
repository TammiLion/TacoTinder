using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	//NOTICE: Add RigidBody2D to your component and check isKinematic

	public Vector2 direction;
	public float speed;
	
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = transform.TransformDirection(direction.normalized*speed);
	}
}
