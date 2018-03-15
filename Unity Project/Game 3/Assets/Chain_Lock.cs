using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Lock : MonoBehaviour {

    // Use this for initialization
    Quaternion ro;
    void Awake()
    {
        ro= transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        transform.rotation = ro;
    }
}
