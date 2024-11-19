using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdmove : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    void Start(){
        Update();
    }

    void Update()
    {
        // Get input from both arrow keys and WASD
        float horizontal = Input.GetAxis("Horizontal"); // Left/Right movement (A/D or Arrow Keys)
        float vertical = Input.GetAxis("Vertical"); // Up/Down movement (W/S or Arrow Keys)

        // Combine the input into a direction vector
        Vector3 direction = new Vector3(horizontal, vertical, 0f);

        // Apply movement to the object
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
