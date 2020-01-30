using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManagerTests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InfoSheet sheet = new InfoSheet("1");
        sheet.dynamicNumericalFields.Add("Dynamic1", (1, 2, 3, 4, 5, 6));
        sheet.dynamicNumericalFields.Add("Dynamic2", (1, 2, 3, 4, 5, 6));
        sheet.dynamicNumericalFields.Add("Dynamic3", (1, 2, 3, 4, 5, 6));
        sheet.staticNumericalFields.Add("Static1", (5, 2, 3, 4, 5));
        sheet.staticNumericalFields.Add("Static2", (1, 2, 3, 4, 5));
        sheet.staticNumericalFields.Add("Static3", (1, 2, 3, 4, 5));
        sheet.textFields.Add("Name", ("Test1", 1, 2, 3, 4));
        sheet.textFields.Add("Text2", ("Test", 1, 2, 3, 4));
        sheet.textFields.Add("Text3", ("Test", 1, 2, 3, 4));

        //SheetFileManager.saveSheetToFile(sheet);
    }
}
