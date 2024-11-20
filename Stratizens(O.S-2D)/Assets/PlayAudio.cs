using Unity.VisualScripting;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource; 
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }
}
