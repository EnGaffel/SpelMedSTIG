using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaffelUpp : MonoBehaviour {

    private int jump = 40;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("BOOM"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
        }

            
    }
}
