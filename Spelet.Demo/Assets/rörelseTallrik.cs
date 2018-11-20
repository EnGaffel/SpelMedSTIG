using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rörelseTallrik : MonoBehaviour {

    public int upp = 5;
    bool startaHopp = false;
    // Use this for initialization
    void Start () {
		
	}
    // Update is called once per frame
    void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("JumpPad"))
        {          
          GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, upp);
        }

    }
}
