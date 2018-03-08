using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Creator : MonoBehaviour {


    public GameObject Player2;
    public GameObject chain_prefab;
    public int chain_size = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GenerateChain();
	}
    void GenerateChain()
    {
        float distance = Mathf.Abs(Player2.transform.position.x - transform.position.x);
        float chain_amount = Mathf.Round(distance / chain_size);
        Vector3 previous = this.transform.position;
        for (int i = 0; i != chain_amount;i++)
        {

            GameObject chain = Instantiate(chain_prefab, previous, Quaternion.identity);
            chain.transform.parent = this.transform;
        }
    }
}
