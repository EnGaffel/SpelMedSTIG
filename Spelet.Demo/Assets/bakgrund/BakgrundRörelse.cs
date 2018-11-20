using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakgrundRörelse : MonoBehaviour {


    Material material;  //bakgrundens material, i detta fall bakgrundsbildem
    Vector2 offset; //hur bakgrunden ska röra sig i förhållande till allt annat
    private bool börjaRöra = false;
    public int xVelocity,yVelocity;
  
    private void Awake()
    {
        material = GetComponent<Renderer>().material;  //bakgrundens material
    }
	// Use this for initialization
	void Start () {
        offset = new Vector2(xVelocity,yVelocity); 
	}

    void OnEnable() {
        StartCoroutine(börjaRöraBakgrund());
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (börjaRöra)  //om man väntat så börjar bakgrunden att röra på sig
        {
            material.mainTextureOffset += (offset * Time.deltaTime/10);   
        }
        else { }
	}
    IEnumerator börjaRöraBakgrund()
    {
        yield return new WaitForSeconds(3); //bakgrunden börajr röra på sig efter 3 sekunder
        börjaRöra = true;
    }
}
