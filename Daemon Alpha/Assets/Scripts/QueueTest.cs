using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//unit test script - may break as development continues
public class QueueTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Queue queue = new Queue();
        InfoSheet sheet = new InfoSheet();
        sheet.dynamicNumericalFields.Add("Dynamic1", (1, 2, 3, 4, 5));
        sheet.dynamicNumericalFields.Add("Dynamic2", (1, 2, 3, 4, 5));
        sheet.dynamicNumericalFields.Add("Dynamic3", (1, 2, 3, 4, 5));
        sheet.staticNumericalFields.Add("Static1", (5, 2, 3, 4, 5));
        sheet.staticNumericalFields.Add("Static2", (1, 2, 3, 4, 5));
        sheet.staticNumericalFields.Add("Static3", (1, 2, 3, 4, 5));
        sheet.textFields.Add("Name", ("Test1", 1, 2, 3, 4));
        sheet.textFields.Add("Text2", ("Test", 1, 2, 3, 4));
        sheet.textFields.Add("Text3", ("Test", 1, 2, 3, 4));


        InfoSheet sheet2 = new InfoSheet();
        sheet2.dynamicNumericalFields.Add("Dynamic1", (1, 2, 3, 4, 5));
        sheet2.dynamicNumericalFields.Add("Dynamic2", (1, 2, 3, 4, 5));
        sheet2.dynamicNumericalFields.Add("Dynamic3", (1, 2, 3, 4, 5));
        sheet2.staticNumericalFields.Add("Static1", (3, 2, 3, 4, 5));
        sheet2.staticNumericalFields.Add("Static2", (1, 2, 3, 4, 5));
        sheet2.staticNumericalFields.Add("Static3", (1, 2, 3, 4, 5));
        sheet2.textFields.Add("Name", ("Test2", 1, 2, 3, 4));
        sheet2.textFields.Add("Text2", ("Test", 1, 2, 3, 4));
        sheet2.textFields.Add("Text3", ("Test", 1, 2, 3, 4));

        InfoSheet sheet3 = new InfoSheet();
        sheet3.dynamicNumericalFields.Add("Dynamic1", (1, 2, 3, 4, 5));
        sheet3.dynamicNumericalFields.Add("Dynamic2", (1, 2, 3, 4, 5));
        sheet3.dynamicNumericalFields.Add("Dynamic3", (1, 2, 3, 4, 5));
        sheet3.staticNumericalFields.Add("Static1", (1, 2, 3, 4, 5));
        sheet3.staticNumericalFields.Add("Static2", (1, 2, 3, 4, 5));
        sheet3.staticNumericalFields.Add("Static3", (1, 2, 3, 4, 5));
        sheet3.textFields.Add("Name", ("Test3", 1, 2, 3, 4));
        sheet3.textFields.Add("Text2", ("Test", 1, 2, 3, 4));
        sheet3.textFields.Add("Text3", ("Test", 1, 2, 3, 4));

        QueueItem item = new QueueItem(sheet);
        queue.addToQueue(item);
        item = new QueueItem(sheet2);
        queue.addToQueue(item);
        item = new QueueItem(sheet3);
        queue.addToQueue(item);

        queue.orderBy("Static1");


        InfoSheet sheet4 = new InfoSheet();
        sheet4.dynamicNumericalFields.Add("Dynamic1", (1, 2, 3, 4, 5));
        sheet4.dynamicNumericalFields.Add("Dynamic2", (1, 2, 3, 4, 5));
        sheet4.dynamicNumericalFields.Add("Dynamic3", (1, 2, 3, 4, 5));
        sheet4.staticNumericalFields.Add("Static1", (4, 2, 3, 4, 5));
        sheet4.staticNumericalFields.Add("Static2", (1, 2, 3, 4, 5));
        sheet4.staticNumericalFields.Add("Static3", (1, 2, 3, 4, 5));
        sheet4.textFields.Add("Name", ("Test4", 1, 2, 3, 4));
        sheet4.textFields.Add("Text2", ("Test", 1, 2, 3, 4));
        sheet4.textFields.Add("Text3", ("Test", 1, 2, 3, 4));

        item = new QueueItem(sheet4);
        queue.addToQueue(item);

        List<string> order = queue.getTextFieldFromEach("Name");

        foreach (string name in order)
            Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
