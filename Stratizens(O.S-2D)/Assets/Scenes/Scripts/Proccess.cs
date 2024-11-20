using UnityEngine;

[CreateAssetMenu(fileName = "NewProcess", menuName = "Process")]
public class Process : ScriptableObject
{
    public string processName; 
    public int BurstTime;
    public int ArrivalTime;
    public int WaitingTime;

    [HideInInspector] public float remainingBurstTime;
    public int TurnaroundTime;

    private void OnEnable()
    {
        remainingBurstTime = BurstTime; 
    }
}
