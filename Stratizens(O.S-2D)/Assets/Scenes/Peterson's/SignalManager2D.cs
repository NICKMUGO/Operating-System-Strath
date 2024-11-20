using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalManager2D : MonoBehaviour
{
    public bool isJunctionOccupied = false; // Tracks if the junction is currently occupied
    public int greenLightLaneID = -1; // ID of the lane with the green light
    private int totalLanes = 4; // Total number of lanes

    private void Start()
    {
        greenLightLaneID = 0; // Start with the first lane
    }

    public bool IsGreenLight(int laneID)
    {
        // Check if the light is green and the junction is not occupied
        return !isJunctionOccupied && greenLightLaneID == laneID;
    }

    public void EnterJunction()
    {
        // Mark the junction as occupied when a car enters
        isJunctionOccupied = true;
    }

    public void ExitJunction()
    {
        // Free the junction and move to the next lane
        isJunctionOccupied = false;

        // Switch to the next lane
        greenLightLaneID = (greenLightLaneID + 1) % totalLanes;
        Debug.Log("Green light for lane: " + greenLightLaneID);
    }
}


