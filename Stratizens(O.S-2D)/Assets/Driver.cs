using System.Collections; //namespaces and you can use everything that is in here provided by unity
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 1f; //speed of the steering
    [SerializeField] float moveSpeed = 0.01f; //speed of the car movement

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; //steering input also Time.deltaTime is used to make the movement frame rate independent in both slow and fast computers
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; //movement input
         transform.Rotate(0, 0, -steerAmount); //rotates the object around the z axis
         transform.Translate(0, moveAmount, 0); //moves the object up
    }
}
