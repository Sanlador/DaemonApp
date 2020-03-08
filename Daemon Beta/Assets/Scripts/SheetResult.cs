using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheetResult : MonoBehaviour
{
    public GameObject text, environment, turnOrder;
    public InfoSheet sheet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addSheetToOrder()
    {
        turnOrder.GetComponent<Timeline>().sheet_button(sheet);
    }
}
