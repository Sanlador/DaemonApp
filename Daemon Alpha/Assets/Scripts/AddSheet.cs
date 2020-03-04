using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSheet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selector, content;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newSheet()
    {
        selector.SetActive(true);
        content.GetComponent<ListFiles>().pile = gameObject;
    }
}
