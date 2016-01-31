using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {	
	public GameObject auraPrefab;
	private Aura aura;
	public Sprite fatty;
	public Sprite[] affiliations;

    public string god;
	public bool isFattyMcFatFuck = false;
    public bool isSuper = false;
    public bool isPossessed = false;
    public Player target;
    int points = 1;

	// Use this for initialization
	void Start () {
		if (target == null) {
			moveToPlayer();
		}
		
		aura = Instantiate(auraPrefab).GetComponent<Aura> ();
		aura.gameObject.transform.SetParent (this.transform);
		aura.transform.localPosition = Vector3.zero;
		if (isFattyMcFatFuck) {
			GetComponent<SpriteRenderer>().sprite = fatty;
			gameObject.transform.localScale= new Vector3(1f, 1f, 1f);
			GetComponent<Moveable>().speed = 0.1f;
			GetComponent<Animator>().speed = 0.5f;
		}
		if (isSuper) {
			gameObject.transform.localScale+= new Vector3(0.3f, 0.3f, 0.3f);
		}
		if(isPossessed) {
			gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		}
	}

	public bool getHit (Player player) {
		if (target != player) {

			// Make the new player the target.
			target = player;

			// Set the aura to the current target. 
			this.aura.setAura (player.playerID - 1);

			// Modify point value
			if (isPossessed) {
				points--;
			} else {
				points++;
			}
			GetComponent<Moveable> ().direction = player.getPosition () - new Vector2 (transform.position.x, transform.position.y);
			if(isFattyMcFatFuck) {
				GetComponent<Moveable> ().speed += 0.01f;
			} else {
				GetComponent<Moveable> ().speed += 0.1f;
			}
			// Let the projectile know we hit a new player.
			return true;
		} else {
			// Must have hit the same player.
			return false;
		}
	}

    public int GetPoints(Player player)
    {
		if (isFattyMcFatFuck) {
			if(isPossessed) {
				if(isSuper) {
					return points - 30;
				} else {
					return points - 20;
				}
			} else if(isSuper) {
				return points+30;
			} else {
				return points+20;
			}
		}

		if (isSuper) {
			if(isPossessed) {
					return points - 10;
			}
			return points + 10;
		}

		if (isPossessed) {
				return points -3;
		}
        return points;
    }

	public void setSpooked(bool isSpooked) {
		//gameObject.GetComponent
	}

	public void moveToPlayer() {
		GetComponent<Moveable>().direction = new Vector2(0,0) - new Vector2(transform.position.x, transform.position.y);
	}
}
