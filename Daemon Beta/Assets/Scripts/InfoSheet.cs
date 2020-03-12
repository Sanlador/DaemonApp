using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSheet
{
    private string name, instanceName;
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
        instanceName = null;
        textFields = new Dictionary<string, (string, float, float, float, float)>();
        staticNumericalFields = new Dictionary<string, (float, float, float, float, float)>();
        dynamicNumericalFields = new Dictionary<string, (float, float, float, float, float, float)>();
    }

    public Dictionary<string, (string, float, float, float, float)> getTextFields()
    {
        return textFields;
    }

    public Dictionary<string, (float, float, float, float, float)> getStaticNumericalFields()
    {
        return staticNumericalFields;
    }

    public Dictionary<string, (float, float, float, float, float, float)> getDynamicNumericalFields()
    {
        return dynamicNumericalFields;
    }

    public string getName()
    {
        return name;
    }

    public void setName(string n)
    {
        name = n;
    }

    public void setInstance(string n)
    {
        instanceName = n;
    }

    public string getInstance()
    {
        return instanceName;
    }

    public void addText(string name, string text, float x, float y, float width, float height)
    {
        textFields.Add(name, (text, x, y, width, height));
    }

    public void addStatic(string name, float val, float x, float y, float width, float height)
    {
        staticNumericalFields.Add(name, (val, x, y, width, height));
    }

    public void addDynamic(string name, float val, float max, float x, float y, float width, float height)
    {
        dynamicNumericalFields.Add(name, (val, max, x, y, width, height));
    }

    public void changeText(string name, string text, float x, float y, float width, float height)
    {
        textFields[name] = (text, x, y, width, height);
    }

    public void changeStatic(string name, int val, float x, float y, float width, float height)
    {
        staticNumericalFields[name] = (val, x, y, width, height);
    }

    public void changeDynamic(string name, int val, int max, float x, float y, float width, float height)
    {
        dynamicNumericalFields[name] = (val, max, x, y, width, height);
    }

    public void removeField(string name, string type)
    {
        if ("dynamic" == type)
        {
            dynamicNumericalFields.Remove(name);
        }
        else if ("static" == type)
        {
            staticNumericalFields.Remove(name);
        }
        else if ("text" == type || "label" == type)
        {
            textFields.Remove(name);
        }
    }

    public void dump()
    {
        foreach (KeyValuePair<string, (string, float, float, float, float)> tup in textFields)
        {
            Debug.Log(tup);
        }
        foreach (KeyValuePair<string, (float, float, float, float, float)> tup in staticNumericalFields)
        {
            Debug.Log(tup);
        }
        foreach (KeyValuePair<string, (float, float, float, float, float, float)> tup in dynamicNumericalFields)
        {
            Debug.Log(tup);
        }
    }
}
