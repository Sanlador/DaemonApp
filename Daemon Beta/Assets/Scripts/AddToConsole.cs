using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToConsole : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject console;
    public string sheetName, field;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendToConsole()
    {
        console.GetComponent<InputField>().text += sheetName + "." + field; 
    }
}
