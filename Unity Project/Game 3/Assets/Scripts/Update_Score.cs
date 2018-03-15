using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_Score : MonoBehaviour {
    GameObject score_keeper;
    Text text;
	// Use this for initialization
	void Start () {
        score_keeper = GameObject.FindGameObjectWithTag("Score Board");
        text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (score_keeper != null)
        {
            text.text = "Score: " + score_keeper.GetComponent<High_Score_Keeper>().score + "\n"
    + "Highscore: " + score_keeper.GetComponent<High_Score_Keeper>().hs;
        }


    }
}
