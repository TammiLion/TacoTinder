using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	public void getHit (Player player) {
		Debug.Log ("Arrow from", player, "hit me!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
