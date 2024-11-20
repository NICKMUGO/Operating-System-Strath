using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public Vector3 offset;    // Offset distance between the camera and the player
    public float smoothSpeed = 0.125f;  // Adjust for smooth movement

    void LateUpdate()
    {
        if (player != null) // Check if the player reference is set
        {
            Vector3 desiredPosition = player.position + offset; // Target position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smooth transition
            transform.position = smoothedPosition; // Update camera position
        }
    }
}
