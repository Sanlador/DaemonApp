using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SheetFileManager
{
    public static void saveSheetToFile(InfoSheet sheet)
    {
        Dictionary<string, (string, float, float, float, float)> dictText = sheet.textFields;
        string fileText = "";
        fileText += sheet.getName() + "\n";

        foreach (KeyValuePair<string, (string, float, float, float, float)> tuple in dictText)
        {
            if (tuple.Key != "")
                fileText += "text," + tuple.Key + "," + tuple.Value.Item1 + "," + tuple.Value.Item2 + "," + tuple.Value.Item3 + "," + tuple.Value.Item4 + "," + tuple.Value.Item5 + "\n";
        }

        Dictionary<string, (float, float, float, float, float)> dictStatic = sheet.staticNumericalFields;
        foreach (KeyValuePair<string, (float, float, float, float, float)> tuple in dictStatic)
        {
            if (tuple.Key != "")
                fileText += "static," + tuple.Key + "," + tuple.Value.Item1 + "," + tuple.Value.Item2 + "," + tuple.Value.Item3 + "," + tuple.Value.Item4 + "," + tuple.Value.Item5 + "\n";
        }

        Dictionary<string, (float, float, float, float, float, float)> dictDynamic = sheet.dynamicNumericalFields;
        foreach (KeyValuePair<string, (float, float, float, float, float, float)> tuple in dictDynamic)
        {
            if (tuple.Key != "")
                fileText += "dynamic," + tuple.Key + "," + tuple.Value.Item1 + "," + tuple.Value.Item2 + "," + tuple.Value.Item3 + "," + tuple.Value.Item4 + "," + tuple.Value.Item5 + "," + tuple.Value.Item6 + "\n";
        }

        fileText += "End file";
        string filePath = @"Sheets\" + sheet.getName() + ".st";

        if (File.Exists(filePath))
        {
            File.WriteAllText(filePath, string.Empty);

        }
        File.WriteAllText(filePath, fileText);
        Debug.Log("Saved");
        //Debug.Log(fileText);
    }

    public static InfoSheet loadSheetFromFile(string filePath)
    {
        InfoSheet sheet = null;
        bool firstLine = true;

        string line;
        System.IO.StreamReader file =
            new System.IO.StreamReader(filePath);
        while ((line = file.ReadLine()) != null)
        {
            if (firstLine)
            {
                sheet = new InfoSheet(line);
                firstLine = false;
            }
            else
            {
                string[] split = line.Split(',');
                if ("text" == split[0])
                {
                    string name = split[1];
                    string text = split[2];
                    float x = float.Parse(split[3]);
                    float y = float.Parse(split[4]);
                    float width = float.Parse(split[5]);
                    float height = float.Parse(split[6]);
                    sheet.addText(name, text, x, y, width, height);
                }
                else if ("static" == split[0])
                {
                    string name = split[1];
                    float val = float.Parse(split[2]);
                    float x = float.Parse(split[3]);
                    float y = float.Parse(split[4]);
                    float width = float.Parse(split[5]);
                    float height = float.Parse(split[6]);
                    sheet.addStatic(name, val, x, y, height, width);
                }
                else if ("dynamic" == split[0])
                {
                    string name = split[1];
                    float val = float.Parse(split[2]);
                    float max = float.Parse(split[3]);
                    float x = float.Parse(split[4]);
                    float y = float.Parse(split[5]);
                    float width = float.Parse(split[6]);
                    float height = float.Parse(split[7]);
                    sheet.addDynamic(name, val, max, x, y, height, width);
                }
            }
        }

        return sheet;
    }
}
