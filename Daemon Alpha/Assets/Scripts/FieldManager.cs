using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldManager : MonoBehaviour
{
    public GameObject nameText, valText, maxText, noteText;

    private InfoSheet sheet;
    string fieldName, type, text;
    int val, max;
    float x, y, width, height;
    bool set;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void initialize(InfoSheet s, string t)
    {
        sheet = s;
        x = GetComponent<RectTransform>().anchoredPosition.x;
        y = GetComponent<RectTransform>().anchoredPosition.y;
        type = t;
        val = max = 0;
        text = "";
        fieldName = "";
        set = false;
    }

    public void setName()
    {
        if (!set)
        {
            fieldName = nameText.GetComponent<Text>().text;
            if ("label" == type)
            {
                sheet.addText(fieldName, "", x, y, 0, 0);
            }
            else if ("dynamic" == type)
            {
                sheet.addDynamic(fieldName, val, max, x, y, 1, 1);
            }
            else if ("static" == type)
            {
                sheet.addStatic(fieldName, val, x, y, 1, 1);
            }
            else if ("text" == type)
            {
                sheet.addText(fieldName, text, x, y, 1, 1);
            }
            set = true;
        }
        else
        {
            print(nameText.GetComponent<Text>().text);
            if ("label" == type)
            {
                sheet.removeField(fieldName, "text");
                fieldName = nameText.GetComponent<Text>().text;
                sheet.addText(fieldName, "", x, y, 0, 0);
            }
            else if ("dynamic" == type)
            {
                sheet.removeField(fieldName, "dynamic");
                fieldName = nameText.GetComponent<Text>().text;
                sheet.addDynamic(fieldName, val, max, x, y, 1, 1);
            }
            else if ("static" == type)
            {
                sheet.removeField(fieldName, "static");
                fieldName = nameText.GetComponent<Text>().text;
                sheet.addStatic(fieldName, val, x, y, 1, 1);
            }
            else if ("text" == type)
            {
                sheet.removeField(fieldName, "text");
                fieldName = nameText.GetComponent<Text>().text;
                sheet.addText(fieldName, text, x, y, 1, 1);
            }
        }
        //
    }

    public void setVal()
    {
        val = int.Parse(valText.GetComponent<Text>().text);
        if ("" != fieldName)
        {
            if ("dynamic" == type)
                sheet.changeDynamic(fieldName, val, max, x, y, width, height);
            else
                sheet.changeStatic(fieldName, val, x, y, width, height);
        }
    }

    public void setMax()
    {
        max = int.Parse(maxText.GetComponent<Text>().text);
        if ("" != fieldName)
        {
            sheet.changeDynamic(fieldName, val, max, x, y, width, height);
        }
    }

    public void setText()
    {
        text = noteText.GetComponent<Text>().text;
        if ("" != fieldName)
        {
            sheet.changeText(fieldName, text, x, y, width, height);
        }
    }

    public void changeCoords()
    {
        x = GetComponent<RectTransform>().anchoredPosition.x;
        y = GetComponent<RectTransform>().anchoredPosition.y;
        print(x);
        print(y);
        if ("label" == type)
        {
            sheet.changeText(fieldName, "", x, y, width, height);
        }
        else if ("dynamic" == type)
        {
            sheet.changeDynamic(fieldName, val, max, x, y, width, height);
        }
        else if ("static" == type)
        {
            sheet.changeStatic(fieldName, val, x, y, width, height);
        }
        else if ("text" == type)
        {
            sheet.changeText(fieldName, text, x, y, width, height);
        }
        print(fieldName);
    }

    public void removeField()
    {
        sheet.removeField(fieldName, type);
        Destroy(gameObject);
    }

    public void setSheet(InfoSheet s)
    {
        sheet = s;
        set = true;
        setName();
    }
}
