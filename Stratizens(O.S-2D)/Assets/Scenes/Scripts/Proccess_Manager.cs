using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Proccess_Manager : MonoBehaviour
{
    public List<SJFS_Algorithm> birds;
    private SJFS_Algorithm currentBird;
    private float elapsedTime = 0f;

    void Start()
    {
        Debug.Log("Before sorting:");
        foreach (var bird in birds)
            {
                Debug.Log($"Bird {bird.name}: ArrivalTime = {bird.process.ArrivalTime}");
            }
        birds.Sort((a,b)=>a.process.ArrivalTime.CompareTo(b.process.ArrivalTime));
        Debug.Log("After sorting:");
        foreach (var bird in birds)
        {
            Debug.Log($"Bird {bird.name}: ArrivalTime = {bird.process.ArrivalTime}");
        }
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        SJFS_Algorithm shortestJobBird = null;
        Debug.Log($"Birds in list: {birds.Count}");

        foreach (var bird in birds){
            Process process = bird.process;
            Debug.Log($"Checking Bird: {bird.name}, ArrivalTime: {process.ArrivalTime}, ElapsedTime: {elapsedTime}, RemainingBurstTime: {process.remainingBurstTime}");

            if(process.ArrivalTime<= elapsedTime && process.remainingBurstTime>0){
                Debug.Log($"Bird {bird.name} is eligible for selection.");
                if(shortestJobBird == null || process.remainingBurstTime < shortestJobBird.process.remainingBurstTime){
                    shortestJobBird = bird;
                    Debug.Log($"Shortest job bird updated to {bird.name}");
                }
            }
        }
        if (shortestJobBird != currentBird){
            if(currentBird !=null){
                Debug.Log($"Stopping execution for {currentBird.name}");
                currentBird.StopExecution();
            }
            currentBird = shortestJobBird;

            if(currentBird != null){
                Debug.Log($"Starting execution for {currentBird.name}");
                currentBird.StartExecution();
            }
        }

        if (currentBird !=null){
            Debug.Log($"Executing {currentBird.name}");
            currentBird.Execute(Time.deltaTime);
        }
    }
}
