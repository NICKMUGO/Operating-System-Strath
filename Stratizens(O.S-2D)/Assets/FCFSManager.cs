using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FCFSManager : MonoBehaviour
{
    public static FCFSManager Instance;

    public TextMeshProUGUI displayText1;
    public TextMeshProUGUI displayText2;
    public TextMeshProUGUI displayText3;
    
    public TextMeshProUGUI displayText4;   // Reference to the TextMeshPro object
    public Queue<EnemyTrackerV2> fcfsQueue = new Queue<EnemyTrackerV2>(); // FCFS queue
    private string currentText = "";  // Store the text to display

 void Start()
    {
        if (displayText1 == null)
        {
            Debug.LogError("Display Text is not assigned.");
        }
    }
    void Awake()
    {
        Instance = this;
    }

    public void EnqueueEnemy(EnemyTrackerV2 enemy)
    {
        fcfsQueue.Enqueue(enemy);
        UpdateDisplay(); // Refresh the text display
    }

    public void ProcessNextEnemy()
    {
        if (fcfsQueue.Count > 0)
        {
            EnemyTrackerV2 currentEnemy = fcfsQueue.Peek(); // Get the first enemy in the queue
            currentEnemy.StartProcessing();
        }
    }

    public void EnemyFinishedProcessing()
    {
        if (fcfsQueue.Count > 0)
        {
            EnemyTrackerV2 finishedEnemy = fcfsQueue.Dequeue(); // Remove the processed enemy
            UpdateDisplay(); // Refresh display after removing the enemy from the queue
            ProcessNextEnemy(); // Start the next enemy if there are more
        }
    }

    public void UpdateDisplay()
{
    string currentText = "";
    foreach (var enemy in fcfsQueue)
    {
        displayText1.text = $"Enemy: {enemy.enemyName}\n";
        displayText2.text = $"Arrival: {enemy.arrivalTime:F2}s\n";
        displayText3.text= $"Turnaround Time: {enemy.TurnaroundTime:F2}s\n";
        displayText4.text= $"Waiting Time: {enemy.WaitingTime:F2}s\n";
    }

    Debug.Log("Updating Display: \n" + currentText);  // Add this line

    // Update the TextMeshPro UI element with the new text
    // if (displayText != null)
    // {
    //     displayText.text = currentText;
    // }
}


    internal void EnqueueEnemy(EnemyTracker enemyTracker)
    {
        throw new NotImplementedException();
    }

    
}
