using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour {

	public Transform player;

	private LineRenderer lr;

	void Awake(){
		lr = GetComponent<LineRenderer> ();
	}

	void FixedUpdate(){
		lr.SetPosition (1, player.position);
		RaycastHit2D hit;
		if (Physics2D.Linecast (transform.position, player.position)) {
			hit = Physics2D.Linecast (transform.position, player.position);
			Destroy(hit.collider.gameObject);	
		}
	}
}
