using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireCooldownModifier;
	public float rotationSpeedModifier;
	public GameObject projectile;

	public void FireWeapon (Vector2 direction, Vector2 position, Player player) {
		GameObject projObject = Instantiate (projectile);
		projObject.GetComponent<Projectile> ().player = player;
		Moveable projectileMovable = projObject.GetComponent<Moveable> ();
		projectileMovable.direction = direction;
		projectileMovable.transform.position = position;
	}
}
