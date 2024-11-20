using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public void OnMouseClick(){
        Debug.Log("Lets Simulate!");
        SceneManager.LoadScene(1);
    }
}
