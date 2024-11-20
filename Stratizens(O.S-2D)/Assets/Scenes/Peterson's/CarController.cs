using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public int laneID; // ID of the lane this car starts in
    public Transform exitPoint; // The exit point for this lane
    public SignalManager2D signalManager; // Reference to SignalManager2D
    public float speed = 2f; // Speed of the car
    private bool isMoving = false;

    void Update()
    {
        // Check if the light for this lane is green and the car is not moving
        if (!isMoving && signalManager.IsGreenLight(laneID))
        {
            isMoving = true; // Start moving the car
            signalManager.EnterJunction(); // Notify SignalManager that the junction is occupied
        }

        // Move the car if it's allowed to
        if (isMoving)
        {
            MoveTowardsExit();
        }
    }

    private void MoveTowardsExit()
    {
        // Move the car towards the exit point
        transform.position = Vector3.MoveTowards(transform.position, exitPoint.position, speed * Time.deltaTime);

        // Check if the car has reached the exit point
        if (Vector3.Distance(transform.position, exitPoint.position) < 0.1f)
        {
            isMoving = false; // Stop moving
            signalManager.ExitJunction(); // Notify SignalManager that the car has exited the junction
            Destroy(gameObject, 1f); // Optional: Destroy the car after it exits
        }
    }
}
