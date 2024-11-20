using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalLight : MonoBehaviour
{
    public int laneID; // ID of the lane this signal represents
    public SignalManager2D signalManager;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Set light colors based on whether the lane has the green light
        if (signalManager.greenLightLaneID == laneID && !signalManager.isJunctionOccupied)
        {
            spriteRenderer.color = Color.green; // Green for go
        }
        else
        {
            spriteRenderer.color = Color.red; // Red for stop
        }
    }
}


