using UnityEngine;

[CreateAssetMenu(fileName = "NewProcess", menuName = "Process")]
public class Process : ScriptableObject
{
    public GameObject bird;

    public string processName; 
    public int BurstTime;
    public int ArrivalTime;
    public int WaitingTime;

    public float remainingBurstTime;
    public int TurnaroundTime;
}
