using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Behavior : MonoBehaviour {
    public AudioClip hit;

    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = hit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.tag == "Enemy"&& GetComponent<SpriteRenderer>().enabled == true)
        {
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
  
    }


    // Update is called once per frame
    void Update()
    {


    }
}

