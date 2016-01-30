using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
	public Sprite[] baseImages;
    int points = 0;
    Vector2 position;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "mob")
        {

            points += coll.GetComponent<Mob>().GetPoints();
            Destroy(coll.gameObject);

        }
    }
}
