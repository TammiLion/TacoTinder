using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
	public Player player;
	public Sprite[] baseImages;
    int points = 0;
    Vector2 position;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Mob") {
			//points += coll.GetComponent<Mob> ().GetPoints (player);
			Destroy (coll.gameObject);
		}
    }
}
