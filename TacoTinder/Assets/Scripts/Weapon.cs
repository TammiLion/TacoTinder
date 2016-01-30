using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireCooldownModifier;
	public float rotationSpeedModifier;
	public GameObject projectile;

	public void FireWeapon (Vector2 direction, Vector2 position) {
		Moveable projectileMovable = Instantiate(projectile).GetComponent<Moveable> ();
		projectileMovable.direction = direction;
		projectileMovable.transform.position = position;
	}
}
