using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
	public Player player;
    public int points = 0;
	public UnityEngine.UI.Text scoreText;
	
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Mob") {
			Debug.Log ("Mob was of God: " + coll.GetComponent<Mob>().god);
			points += coll.GetComponent<Mob> ().GetPoints (player);
			scoreText.text = "Score: " + points;
			Destroy (coll.gameObject);
		}
    }
}
