using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBird : MonoBehaviour
{
    public float speed = 5f;

    public Vector3 direction = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
