using UnityEngine;
using System.Collections;

public class WallBehaviour : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mob")
        {
            // Turn the mob around for now.
            Moveable mobMoveable = other.GetComponent<Moveable>();
            Vector2 mobDirection = mobMoveable.direction;
            // Inverse the direction of the mob.
            mobMoveable.direction = new Vector2(-1 * mobDirection.x + (Random.value / 2f), -1 * mobDirection.y + (Random.value / 1.5f));
        }
    }


}
