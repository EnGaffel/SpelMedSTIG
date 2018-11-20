using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePosition : MonoBehaviour {

    public bool FreezeX = false;
    public bool FreezeY = false;
    public bool FreezeZ = false;


    private Vector3 m_OriginPos;

    // Use this for initialization
    void Start() {

        m_OriginPos = transform.position;
 
    }

    // Update is called once per frame
    void Update() {


        Vector3 currentPos = transform.position;
        if (FreezeX)
            currentPos.x = m_OriginPos.x;
        if (FreezeY)
            currentPos.y = m_OriginPos.y;
        if (FreezeZ)
            currentPos.z = m_OriginPos.z;
        transform.position = currentPos;



    }


}
