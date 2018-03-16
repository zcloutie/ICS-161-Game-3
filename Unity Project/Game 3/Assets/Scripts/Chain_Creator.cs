using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Creator : MonoBehaviour {


    public GameObject Player2;
    public GameObject chain_prefab;

    GameObject[] chains;
    GameObject chain;

    public float max_distance = 15f;
    float distance = 0f;

    bool is_disabled =false;
    bool is_enabled = true;

    public int kills = 0;

    bool on_wall = false;
	// Use this for initialization
	void Start () {

        GenerateChain();
    }


    
    // Update is called once per frame
    void Update () {
        distance = Vector3.Distance(this.transform.position, Player2.transform.position);

        CheckChain();
        if (distance >= max_distance &&!is_disabled)
        {
            BreakChain();
          //  Debug.Log("Breaking");

        }
        else if(distance < max_distance &&!is_enabled && !on_wall)
        {

            LinkChain();
         //     Debug.Log("Linking");
        }
    }
    void GenerateChain()
    {

        float distance = Mathf.Abs(Player2.transform.position.x - transform.position.x); //distance between 2 players
        float chain_size = chain_prefab.GetComponent<SpriteRenderer>().bounds.size.x/2;
        int chain_amount = Mathf.RoundToInt(distance /chain_size )*2;//how many chains to spawn
        GameObject previous = this.gameObject;//last chain position
        Rigidbody2D Last_Chain = this.GetComponent<Rigidbody2D>();//last rigidbody to connect
        float distance_x = (Player2.transform.position.x - this.transform.position.x) / chain_amount;
        float distance_y = (Player2.transform.position.y - this.transform.position.y) / chain_amount;


        //generate array of chains for collsion
        chains = new GameObject[chain_amount]; 
        
        for (int i = 0; i <= chain_amount;i++)
        {

            if ((previous.transform.position.x + distance_x) <= Player2.transform.position.x)
            {
                chain = Instantiate(chain_prefab, new Vector3(previous.transform.position.x + distance_x, previous.transform.position.y + distance_y), Quaternion.identity);

                previous = chain;
                chain.transform.parent = this.transform;
                chain.GetComponent<HingeJoint2D>().connectedBody = Last_Chain;
                Last_Chain = chain.GetComponent<Rigidbody2D>();

                chains[i] = chain;
            }

        }
        Player2.GetComponent<HingeJoint2D>().connectedBody = Last_Chain;
    }

    void BreakChain()
    {
        for (int i = 0; i != chains.Length; i++)
        {
            chains[i].GetComponent<SpriteRenderer>().enabled = false;
            chains[i].GetComponent<ParticleSystem>().enableEmission = false;
        }
        is_disabled = true;
        is_enabled = false;
        
    }

    void LinkChain()
    {
        for (int i = 0; i != chains.Length; i++)
        {
            chains[i].GetComponent<SpriteRenderer>().enabled = true;
            chains[i].GetComponent<ParticleSystem>().enableEmission = true;
        }
        is_disabled = false;
        is_enabled = true;
    }
    public void CheckChain()
    {
        int count = 0;
        for (int i = 0; i != chains.Length; i++)
        {
            if (chains[i].GetComponent<Chain_Behavior>().on_collision_wall == true)
            {

                BreakChain();
                on_wall = true;
            }
            else
            {
                count++;
            }
        }
        if (count == chains.Length)
        {
            LinkChain();
            on_wall = false;
        }
      
    }
}
