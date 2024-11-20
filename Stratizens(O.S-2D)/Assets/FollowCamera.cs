using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //this things (camera) will follow the car object
    [SerializeField] GameObject thingToFollow; //car object
   
    // Update is called once per frame
    void LateUpdate()
    {
       transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10); //camera follows the car object. vector3 is used to move the camera in the z axis
    }
}
