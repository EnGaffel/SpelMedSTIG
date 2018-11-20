using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburgare : MonoBehaviour {

    public int movevelocity=5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(movevelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("Vänd"))
        {
            movevelocity = -1 * movevelocity;
        }
        else if (col.gameObject.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
        }

    }

    
}
