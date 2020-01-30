using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSheet
{
    private string name;
    //Field lists

    //first element is the text in the field, the last four are the x, y, width and height
    public Dictionary<string, (string, float, float, float, float)> textFields;
    //first element is the number in the field, the last four are the x, y, width and height
    public Dictionary<string, (float, float, float, float, float)> staticNumericalFields;
    //first element is the current number in the field second is the max, 
    //the last four are the x, y, width and height
    public Dictionary<string, (float, float, float, float, float, float)> dynamicNumericalFields;
    

    public InfoSheet(string n)
    {
        name = n;
        textFields = new Dictionary<string, (string, float, float, float, float)>();
        staticNumericalFields = new Dictionary<string, (float, float, float, float, float)>();
        dynamicNumericalFields = new Dictionary<string, (float, float, float, float, float, float)>();
    }

    public string getName()
    {
        return name;
    }

    
}
