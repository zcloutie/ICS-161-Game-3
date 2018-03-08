using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause_menu : MonoBehaviour {

    // Use this for initialization
    GameObject[] parts;
    void Awake()
    {
        parts = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i <parts.Length;i++)
        {
            parts[i].SetActive(false);
        }
        GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                GetComponent<Image>().enabled = false;
            }

            else
            {
                Time.timeScale = 0;
                GetComponent<Image>().enabled = true;
            }
        }

      
		if (GetComponent<Image>().enabled == true)
        {
            for (int i = 0; i <parts.Length; i++)
            {
                parts[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].SetActive(false);
            }
        }
	}
}
