using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class High_Score_Keeper : MonoBehaviour {

    public int hs = 0;
    public int score = 0;
    GameObject Main_Chain;

    private static bool created = false;

    bool do_reload = false;
    // Use this for initialization
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else

            Destroy(this.gameObject);

    
    }
    void Start () {

        Main_Chain = GameObject.FindGameObjectWithTag("Main Chain"); 
	}
	
	// Update is called once per frame
	void Update () {
        
        if (SceneManager.GetActiveScene().name.ToString() == "Death")
        {
       
            do_reload = true;
        }
        if (SceneManager.GetActiveScene().name.ToString() == "Main" && do_reload)
        {
  
            Main_Chain = GameObject.FindGameObjectWithTag("Main Chain");
            score = 0;
            do_reload = false;
        }
 
        ;
        if (Main_Chain != null)
        {
            score = Main_Chain.GetComponent<Chain_Creator>().kills;
        }
        if (score >= hs)
            hs = score;
 
    }
}
