using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : MonoBehaviour {
    Vector3 spawn;
	// Use this for initialization
	void Start () {
        spawn = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = spawn;
	}
}
