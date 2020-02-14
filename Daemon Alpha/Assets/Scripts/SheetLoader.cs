using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheetLoader : MonoBehaviour
{
    public GameObject text, label, dyn, stat, f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateSheet(string fileName)
    {
        InfoSheet sheet = SheetFileManager.loadSheetFromFile(fileName);
        GameObject field;
        foreach (KeyValuePair<string, (string, float, float, float, float)> tuple in sheet.getTextFields())
        {
            if (tuple.Value.Item1 == "")
            {
                field = Instantiate(label, transform);
                field.GetComponent<Text>().text = tuple.Key;
                field.GetComponent<RectTransform>().localPosition = new Vector3(tuple.Value.Item2, tuple.Value.Item3, 0);
               }
            else
            {
                field = Instantiate(text, transform);
                field.GetComponent<Holder>().held.GetComponent<Text>().text = tuple.Key;
                field.GetComponent<Text>().text = tuple.Value.Item1; 
                field.GetComponent<RectTransform>().localPosition = new Vector3(tuple.Value.Item2, tuple.Value.Item3, 0);
            }
        }
        
        foreach(KeyValuePair <string, (float, float, float, float, float)> tuple in sheet.getStaticNumericalFields())
        {
            field = Instantiate(stat, transform);
            field.GetComponent<Holder>().held.GetComponent<Text>().text = tuple.Value.Item1.ToString();
            field.GetComponent<Text>().text = tuple.Key;
            field.GetComponent<RectTransform>().localPosition = new Vector3(tuple.Value.Item2, tuple.Value.Item3, 0);
        }

        foreach(KeyValuePair<string, (float, float, float, float, float, float)> tuple in sheet.getDynamicNumericalFields())
        {
            field = Instantiate(dyn, transform);
            field.GetComponent<Text>().text = tuple.Key;
            field.GetComponent<Holder>().held.GetComponent<Text>().text = tuple.Value.Item1.ToString();
            field.GetComponent<Holder>().held1.GetComponent<Text>().text = tuple.Value.Item2.ToString();
            field.GetComponent<RectTransform>().localPosition = new Vector3(tuple.Value.Item3, tuple.Value.Item4, 0);
        }
    }

    public void load()
    {
        string filename = f.GetComponent<Text>().text;
        generateSheet(@"sheets\" + filename + ".st");
    }
}
