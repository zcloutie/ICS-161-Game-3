using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Creator : MonoBehaviour {


    public GameObject Player2;
    public GameObject chain_prefab;

    GameObject[] chains;
    GameObject chain;
	// Use this for initialization
	void Start () {

        GenerateChain();



    }

    // Update is called once per frame
    void Update () {

    }
    void GenerateChain()
    {

        float distance = Mathf.Abs(Player2.transform.position.x - transform.position.x); //distance between 2 players
        float chain_size = chain_prefab.GetComponent<SpriteRenderer>().bounds.size.x/2;
        int chain_amount = Mathf.RoundToInt(distance /chain_size );//how many chains to spawn
        GameObject previous = this.gameObject;//last chain position
        Rigidbody2D Last_Chain = this.GetComponent<Rigidbody2D>();//last rigidbody to connect
        float distance_x = (Player2.transform.position.x - this.transform.position.x) / chain_amount;
        float distance_y = (Player2.transform.position.y - this.transform.position.y) / chain_amount;

        
        for (int i = 0; i <= chain_amount;i++)
        {

            if ((previous.transform.position.x + distance_x) <= Player2.transform.position.x)
            {
                chain = Instantiate(chain_prefab, new Vector3(previous.transform.position.x + distance_x, previous.transform.position.y + distance_y), Quaternion.identity);

                previous = chain;
                chain.transform.parent = this.transform;
                chain.GetComponent<HingeJoint2D>().connectedBody = Last_Chain;
                Last_Chain = chain.GetComponent<Rigidbody2D>();


            }

        }
        Player2.GetComponent<HingeJoint2D>().connectedBody = Last_Chain;
    }
}
