using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheetLoader : MonoBehaviour
{
    public GameObject text, label, dyn, stat, f;
    public InfoSheet sheet;
    string instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateSheet(string fileName, bool template = false)
    {
        sheet = SheetFileManager.loadSheetFromFile(fileName);
        if (!template)
            sheet.setInstance(instance.Split('.')[1]);

        GameObject field;
        foreach (KeyValuePair<string, (string, float, float, float, float)> tuple in sheet.getTextFields())
        {
            if (tuple.Value.Item1 == "")
            {
                field = Instantiate(label, transform);
                if (template)
                {
                    field.GetComponent<FieldManager>().setSheet(sheet, tuple.Key, tuple.Value.Item2, tuple.Value.Item3);
                    field.GetComponent<DragHandler>().dropLocation = gameObject;
                    field.GetComponent<InputField>().text = tuple.Key;
                }
                else
                {
                    field.GetComponent<Text>().text = tuple.Key;
                }
                field.GetComponent<RectTransform>().localPosition = new Vector3(tuple.Value.Item2, tuple.Value.Item3, 0);
            }
            else
            {
                field = Instantiate(text, transform);
                if (template)
                {
                    field.GetComponent<FieldManager>().setSheet(sheet, tuple.Key, tuple.Value.Item1, tuple.Value.Item2, tuple.Value.Item3);
                    field.GetComponent<DragHandler>().dropLocation = gameObject;
                    field.GetComponent<FieldManager>().setSheet(sheet, tuple.Key, tuple.Value.Item1, tuple.Value.Item2, tuple.Value.Item3);
                    field.GetComponent<DragHandler>().dropLocation = gameObject;
                    field.GetComponent<InputField>().text = tuple.Value.Item1;
                    field.GetComponent<Holder>().held.GetComponent<InputField>().text = tuple.Key;
                }
                else
                {
                    field.GetComponent<Holder>().held1.GetComponent<InputField>().text = tuple.Value.Item1;
                    field.GetComponent<Holder>().held.GetComponent<Text>().text = tuple.Key;
                }
                field.GetComponent<RectTransform>().localPosition = new Vector3(tuple.Value.Item2, tuple.Value.Item3, 0);
            }
        }
        
        foreach(KeyValuePair <string, (float, float, float, float, float)> tuple in sheet.getStaticNumericalFields())
        {
            field = Instantiate(stat, transform);
            if (template)
            {
                field.GetComponent<FieldManager>().setSheet(sheet, tuple.Key, tuple.Value.Item1, tuple.Value.Item2, tuple.Value.Item3);
                field.GetComponent<DragHandler>().dropLocation = gameObject;
                field.GetComponent<Holder>().held1.GetComponent<InputField>().text = tuple.Key;
                field.GetComponent<InputField>().text = tuple.Value.Item1.ToString();
            }
            else
            {
                field.GetComponent<Text>().text = tuple.Key;
                field.GetComponent<Holder>().held.GetComponent<Text>().text = tuple.Value.Item1.ToString();
            }
            field.GetComponent<RectTransform>().localPosition = new Vector3(tuple.Value.Item2, tuple.Value.Item3, 0);
        }

        foreach(KeyValuePair<string, (float, float, float, float, float, float)> tuple in sheet.getDynamicNumericalFields())
        {
            field = Instantiate(dyn, transform);
            if (template)
            {
                field.GetComponent<FieldManager>().setSheet(sheet, tuple.Key, tuple.Value.Item1, tuple.Value.Item2, tuple.Value.Item3, tuple.Value.Item4);
                field.GetComponent<DragHandler>().dropLocation = gameObject;
                field.GetComponent<Holder>().held2.GetComponent<InputField>().text = tuple.Key;
                field.GetComponent<Holder>().held.GetComponent<InputField>().text = tuple.Value.Item1.ToString();
                field.GetComponent<Holder>().held1.GetComponent<InputField>().text = tuple.Value.Item2.ToString();
            }
            else
            {
                field.GetComponent<Text>().text = tuple.Key;
                field.GetComponent<Holder>().held.GetComponent<InputField>().text = tuple.Value.Item1.ToString(); 
                field.GetComponent<Holder>().held1.GetComponent<Text>().text = tuple.Value.Item2.ToString();
            }
            
            field.GetComponent<RectTransform>().localPosition = new Vector3(tuple.Value.Item3, tuple.Value.Item4, 0);

        }
    }

    public void loadFromButton(string file)
    {
        generateSheet(file, true);
    }

    public void load(string filename)
    {
        instance = filename;
        generateSheet(@"Instances\" + filename + ".st");
    }

    public InfoSheet getSheet()
    {
        return sheet;
    }
}
