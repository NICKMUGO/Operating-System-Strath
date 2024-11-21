using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrackerV2 : MonoBehaviour
{
 public string enemyName;
    public float arrivalTime;
    public float deathTime;
    public float burstStartTime;

    public float TurnaroundTime => deathTime - arrivalTime;
    public float WaitingTime => TurnaroundTime - (deathTime - burstStartTime);

    public bool isProcessing = false;

    void Start()
    {
        arrivalTime = Time.time; // Log the arrival time
        FCFSManager.Instance.EnqueueEnemy(this); // Add to FCFS queue
    }

    public void StartProcessing()
    {
        isProcessing = true;
        burstStartTime = Time.time; // Start burst time
    }

    public void RecordDeath()
    {
        deathTime = Time.time; // Log death time
        FCFSManager.Instance.EnemyFinishedProcessing(); // Notify manager
        Destroy(gameObject); // Remove enemy from the scene
    }



























}