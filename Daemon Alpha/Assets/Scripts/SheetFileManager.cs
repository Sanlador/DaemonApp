using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetFileManager 
{
    public static void saveSheetToFile(InfoSheet sheet)
    {
        Dictionary<string, (string, float, float, float, float)> dictText = sheet.textFields;
        string file = "";
        file += sheet.getName() + "\n";

        foreach(KeyValuePair<string, (string, float, float, float, float)> tuple in dictText)
        {
            file += tuple.Key + "," + tuple.Value.Item1 + "," + tuple.Value.Item2 + "," + tuple.Value.Item3 + "," + tuple.Value.Item4 + "," + tuple.Value.Item5 + "\n";
        }

        Dictionary<string, (float, float, float, float, float)> dictStatic = sheet.staticNumericalFields;
        foreach (KeyValuePair<string, (float, float, float, float, float)> tuple in dictStatic)
        {
            file += tuple.Key + "," + tuple.Value.Item1 + "," + tuple.Value.Item2 + "," + tuple.Value.Item3 + "," + tuple.Value.Item4 + "," + tuple.Value.Item5 + "\n";
        }

        Dictionary<string, (float, float, float, float, float, float)> dictDynamic = sheet.dynamicNumericalFields;
        foreach (KeyValuePair<string, (float, float, float, float, float, float)> tuple in dictDynamic)
        {
            file += tuple.Key + "," + tuple.Value.Item1 + "," + tuple.Value.Item2 + "," + tuple.Value.Item3 + "," + tuple.Value.Item4 + "," + tuple.Value.Item5 + "," + tuple.Value.Item6 + "\n";
        }

        Debug.Log(file);
    }
}
