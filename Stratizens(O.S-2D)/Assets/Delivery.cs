using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1); //color of the package when it is picked up also color32 is a 32 bit color
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1); //color of the package when it is not picked up
    [SerializeField] float destroyDelay = 0.5f; //delay to destroy the package
    bool hasPackage; //boolean to check if the package is picked up or not
    SpriteRenderer spriteRenderer; //sprite renderer to change the color of the package

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>(); //get the sprite renderer component
    }
    void OnCollisionEnter2D(Collision2D other) 
   {
       Debug.Log("Collision Detected");
   }
   void OnTriggerEnter2D(Collider2D other)
   {
       // if the thing we trigger is the package then we print package is picked up
       if(other.tag == "Package" && !hasPackage) //prevents picking up multiple packages
       {
           Debug.Log("Package Picked Up");
           hasPackage = true;
           spriteRenderer.color = hasPackageColor; //change the color of the package to hasPackageColor
           Destroy(other.gameObject, destroyDelay); //destroy the package after 0.5 seconds 
       }
        if(other.tag == "Customer" && hasPackage)
       {
           Debug.Log("Package Delivered");
           hasPackage = false; //package is delivered
           spriteRenderer.color = noPackageColor; //change the color of the package to noPackageColor
       }
}
}
