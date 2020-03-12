using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnActiveObject : MonoBehaviour
{
    // Start is called before the first frame update
    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    public void activate()
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
