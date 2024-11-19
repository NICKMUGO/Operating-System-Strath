using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SJFS_Algorithm : MonoBehaviour
{
    public Process process;

    private SpriteRenderer birdRenderer;
    void Start()
    {
        birdRenderer = GetComponent<SpriteRenderer>();
        birdRenderer.enabled=false; 
        
    }
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
            birdRenderer.enabled = false; 
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
    }
}
