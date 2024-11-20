using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunctionController2D : MonoBehaviour
{
    private SignalManager2D signalManager;

    void Start()
    {
        signalManager = FindObjectOfType<SignalManager2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!signalManager.isJunctionOccupied)
        {
            signalManager.EnterJunction();
            Debug.Log("Entered Junction: " + other.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        signalManager.ExitJunction();
        Debug.Log("Exited Junction: " + other.name);
    }
}

