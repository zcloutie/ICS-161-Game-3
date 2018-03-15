using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Click : MonoBehaviour {


    // Use this for initialization

    public void On_Click (string Command) // The script that deals buttons. It takes a string command to serve different purposes
    {
    //    GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Command == "Quit")
            Application.Quit();
        else if (Command== "Restart")
        {

            //restart

            SceneManager.LoadScene("Main");

            GameObject.FindGameObjectWithTag("Main Chain").GetComponent<Chain_Creator>().kills = 0;
            GameObject.FindGameObjectWithTag("Score Board").GetComponent<High_Score_Keeper>().manual_restart();
            Time.timeScale = 1;
        }
        else if (Command == "Start")
        {
            SceneManager.LoadScene("Main");
        }
        else if (Command =="Goal")
        {
            SceneManager.LoadScene("Controls");
        }
        else if (Command =="StartOver")
        {
  //          SceneManager.LoadScene("Scene1");
    //        if (GameObject.FindGameObjectWithTag("Player") !=null)
      //      Player.GetComponent<Rigidbody2D>().simulated = true;
        //    Time.timeScale = 1;
        }
        else if (Command == "Controls")
        {

            GameObject Control_Menu = GameObject.FindGameObjectWithTag("Control");
            if (Control_Menu.GetComponent<CanvasGroup>().alpha == 0)
            {
                Control_Menu.GetComponent<CanvasGroup>().alpha = 1;
                Control_Menu.GetComponent<CanvasGroup>().interactable = true;
                Control_Menu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
            else
            {
                Control_Menu.GetComponent<CanvasGroup>().alpha = 0;
                Control_Menu.GetComponent<CanvasGroup>().interactable = false;
                Control_Menu.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

        //toggle bring up control menu

    }
}
