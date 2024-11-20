using TMPro;
using UnityEngine;

public class SimpleTextTest : MonoBehaviour
{
    public TextMeshProUGUI testText;

    void Start()
    {
        if (testText != null)
        {
            testText.text = "Hello, World!";
        }
        else
        {
            Debug.LogError("Test Text is not assigned.");
        }
    }
}
