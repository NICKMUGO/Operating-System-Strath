using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SJFS_Algorithm : MonoBehaviour
{
    public Process process; // Process object containing its properties
    public TextMeshProUGUI turnaroundTimeDisplay; // To display turnaround time (optional)

    private SpriteRenderer birdRenderer; 
    public Vector3 movementDirection = Vector3.right; 
    public float movementSpeed = 5f; 

    private bool isExecuting = false; // Track if the process is currently executing
    private float completionTime = 0f; // Stores the time when execution finishes

    void Start()
    {
        birdRenderer = GetComponent<SpriteRenderer>();
        birdRenderer.enabled = false; 
    }

    public void StartExecution()
    {
        if (birdRenderer != null)
        {
            birdRenderer.enabled = true; 
        }
        isExecuting = true;
    }

    public void StopExecution()
    {
        if (birdRenderer != null)
        {
            birdRenderer.enabled = false;
        }
        isExecuting = false;
    }

    public void Execute(float deltaTime)
    {
        if (isExecuting && process.remainingBurstTime > 0)
        {
            process.remainingBurstTime -= deltaTime;

            // Ensure remaining burst time doesn't go below zero
            process.remainingBurstTime = Mathf.Max(0, process.remainingBurstTime);

            // If the process is finished, calculate turnaround time
            if (process.remainingBurstTime == 0 && completionTime == 0)
            {
                completionTime = Time.time; // Record the time when execution completes
                process.TurnaroundTime = (int)(completionTime - process.ArrivalTime); // Calculate turnaround time

                // Optional: Display the turnaround time in the UI
                if (turnaroundTimeDisplay != null)
                {
                    turnaroundTimeDisplay.text = $"{process.processName} Turnaround Time: {process.TurnaroundTime:F2} seconds";
                }

                StopExecution(); // Stop execution since the process is complete
            }

            PlayerControlledMovement(deltaTime);
        }
    }

    private void PlayerControlledMovement(float deltaTime)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0).normalized;

        transform.Translate(movement * movementSpeed * deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log($"Bird {process.processName} collided with {collider.name}");
        if (birdRenderer != null)
        {
            birdRenderer.enabled = false;
        }
    }
}
