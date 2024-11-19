using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Proccess_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SJFS_Algorithm> birds;
    private SJFS_Algorithm currentBird;
    private float elapsedTime = 0f;

    void Start()
    {
        birds.Sort((a,b)=>a.process.ArrivalTime.CompareTo(b.process.ArrivalTime));
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        SJFS_Algorithm shortestJobBird = null;

        foreach (var bird in birds){
            Process process = bird.process;

            if(process.ArrivalTime<= elapsedTime && process.remainingBurstTime>0){
                if(shortestJobBird == null || process.remainingBurstTime < shortestJobBird.process.remainingBurstTime){
                    shortestJobBird = bird;
                }
            }
        }
        if (shortestJobBird != currentBird){
            if(currentBird !=null){
                currentBird.StopExecution();
            }
            currentBird = shortestJobBird;

            if(currentBird != null){
                currentBird.StartExecution();
            }
        }

        if (currentBird !=null){
            currentBird.Excecute(Time.deltaTime);
        }
    }
}
