using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setName : MonoBehaviour
{
    public GameObject name;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void set(string n)
    {
        name.GetComponent<Text>().text = n;
    }
}
