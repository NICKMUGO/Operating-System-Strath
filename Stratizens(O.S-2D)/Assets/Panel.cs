using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panel;

    // Update is called once per frame
    public void displayPanel()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
