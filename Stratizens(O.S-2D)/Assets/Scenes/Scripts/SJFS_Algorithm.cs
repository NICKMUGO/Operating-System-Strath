using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SJFS_Algorithm : MonoBehaviour
{
    public Process process;

    private Renderer birdRenderer;
    void Start()
    {
        birdRenderer = GetComponent<Renderer>();
        birdRenderer.enabled=false; 
        
    }

    // Update is called once per frame
    public void StartExecution()
    {
        if(birdRenderer !=null){
            birdRenderer.enabled = true;
        }
        
    }
    public void StopExecution()
    {
        if (birdRenderer != null)
        {
            birdRenderer.enabled = false; // Make bird invisible
        }
    }
    public void Excecute(float deltaTime){
        if(process.remainingBurstTime>0){
            process.remainingBurstTime-= deltaTime;

            transform.Translate(Vector3.forward * (1/process.BurstTime)* deltaTime);

            process.remainingBurstTime = Mathf.Max(0, process.remainingBurstTime);
        }
    }
    void OnTriggerEnter(Collider collider){
        Renderer renderer= GetComponent<Renderer>();
        if(renderer != null){
            renderer.enabled= false;
        }
        Debug.Log("Im in");
        // Destroy(gameObject);
    }
}
