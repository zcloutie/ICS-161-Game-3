using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy2Follow : MonoBehaviour
{
	
    public Transform position;
	public float speed = 2;
	public float nextWaypointDistance = 3;
	public Path path;
	public float repathRate = 0.5f;

	private int currentWaypoint = 0;
	private float lastRepath = float.NegativeInfinity;
	private Seeker seeker;
	private Transform targetPosition;
    void Awake()
    {
		seeker = GetComponent<Seeker> ();
		targetPosition = GameObject.FindGameObjectWithTag("Player2").transform;
    }

	void OnPathComplete(Path p){
		Debug.Log ("A path was calculated. Did it fail? " + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	void Update(){
		targetPosition = GameObject.FindGameObjectWithTag("Player2").transform;
		if (Time.time > lastRepath + repathRate && seeker.IsDone ()) {
			lastRepath = Time.time;

			// Start a new path to the targetPosition, call the the OnPathComplete function
			// when the path has been calculated (which may take a few frames depending on the complexity)
			seeker.StartPath (transform.position, targetPosition.position, OnPathComplete);
		}

		if (path == null) {
			// We have no path to follow yet, so don't do anything
			return;
		}

		if (currentWaypoint > path.vectorPath.Count)
			return;
		if (currentWaypoint == path.vectorPath.Count) {
			Debug.Log ("End Of Path Reached");
			currentWaypoint++;
			return;
		}

		// Direction to the next waypoint
		// Normalize it so that it has a length of 1 world unit
		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
		// Multiply the direction by our desired speed to get a velocity
		Vector3 velocity = dir * speed;
		// Note that SimpleMove takes a velocity in meters/second, so we should not multiply by Time.deltaTime
		transform.LookAt((path.vectorPath [currentWaypoint] - transform.position).normalized);
		//transform.Translate(dir.forward * speed * Time.deltaTime);

		// The commented line is equivalent to the one below, but the one that is used
		// is slightly faster since it does not have to calculate a square root
		//if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
		if ((transform.position - path.vectorPath [currentWaypoint]).sqrMagnitude < nextWaypointDistance * nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}
}
