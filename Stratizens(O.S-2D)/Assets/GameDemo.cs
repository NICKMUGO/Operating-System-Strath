using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDemo : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");

    }

}
