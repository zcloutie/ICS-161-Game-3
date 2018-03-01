using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Follow : MonoBehaviour
{
    GameObject target;
    public Transform position;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
    }
}
