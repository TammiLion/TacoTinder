using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float fireCooldownModifier;
	public float rotationSpeedModifier;
	public GameObject projectile;


	// Use this for initialization
	void Start () {
		
	}

	public void FireWeapon (Vector2 direction) {
		Moveable projectileMovable = Instantiate(projectile).GetComponent<Moveable> ();
		projectileMovable.direction = direction;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
