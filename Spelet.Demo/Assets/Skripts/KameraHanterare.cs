using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHanterare : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        transform.Translate(Vector3.right * 1 / 15);

    }
}
