using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyManager : MonoBehaviour {
    //public PlayerHealth playerHealth;
    public GameObject enemy;
    public GameObject enemy2;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

	private AIDestinationSetter ai1;
	private AIDestinationSetter ai2;
	// Use this for initialization
	void Start () {
		ai1 = enemy.GetComponent<AIDestinationSetter> ();
		ai2 = enemy2.GetComponent<AIDestinationSetter> ();
		ai1.target = GameObject.FindGameObjectWithTag("Player").transform;
		ai2.target = GameObject.FindGameObjectWithTag("Player2").transform;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
        //if(playerHealth.currentHealth <= 0f)
        //{
            //return;
        //}

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Instantiate(enemy2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
