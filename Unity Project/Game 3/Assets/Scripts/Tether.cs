using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour {

    GameObject wall;
    public Transform player;
    public Transform player2;

	private LineRenderer lr;

    void Awake(){
        lr = GetComponent<LineRenderer> ();
	}

	void FixedUpdate(){
        lr.SetPosition(0, player2.position);
		lr.SetPosition (1, player.position);
		RaycastHit2D hit;
		if (Physics2D.Linecast (transform.position, player.position)) {
			hit = Physics2D.Linecast (transform.position, player.position);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);
            }
		}
	}
}
