﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {
    GameObject target;
    public Transform position;
	public float speed;


    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(target.transform);
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
