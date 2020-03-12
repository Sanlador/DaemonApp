using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class ListFiles : MonoBehaviour
{
    public string folder;
    public GameObject templateResult, inputContents, sheet, parent, selectionScreen, console;
    public GameObject pile;
    List<GameObject> resultList;
    List<string> fileNames;
    public bool isSheetPile;
    bool newPile = false;
    int fileCount;
    List<String> fileList;

    void Start()
    {
        fileNames = new List<string>();
        resultList = new List<GameObject>();
        fileCount = Directory.GetFiles(folder).Length;
        fileList = new List<string>();

        foreach (string name in Directory.GetFiles(folder))
        {
            string rm = folder + "\\";
            string sheetName = name.Remove(name.IndexOf(rm), rm.Length);

            fileList.Add(name);

            sheetName = sheetName.Substring(0, sheetName.Length - 3);
            GameObject result = Instantiate(templateResult, transform.position, Quaternion.identity);
            result.GetComponent<LoadSheetFromSelector>().parent = parent;
            result.GetComponent<LoadSheetFromSelector>().console = console;

            if (isSheetPile)
            {
                result.GetComponent<LoadSheetFromSelector>().isSheetPile(pile);
                result.GetComponent<LoadSheetFromSelector>().selector = selectionScreen;
            }

            resultList.Add(result);
            fileNames.Add(sheetName);
            result.transform.SetParent(gameObject.transform);
            result.GetComponent<SetResultName>().setName(sheetName);
            result.GetComponent<LoadSheetFromSelector>().sheet = sheet;
        }
    }

    public void filter()
    {
        string query = inputContents.GetComponent<Text>().text;
        if (query != "" && query != " ")
        {
            for (int i = 0; i < resultList.Count; i++)
            {
                if (!fileNames[i].Contains(query))
                {
                    resultList[i].SetActive(false);
                }
            }
        }
        else
        {
            foreach (GameObject result in resultList)
            {
                result.SetActive(true);
            }
        }
    }

    public void setPile()
    {
        foreach (GameObject result in resultList)
        {
            result.GetComponent<LoadSheetFromSelector>().setNewPile(pile);
        }
    }

    public void isNewPile()
    {
        newPile = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fileCount != Directory.GetFiles(folder).Length)
        {
            foreach (string name in Directory.GetFiles(folder))
            {
                if (!fileList.Contains(name))
                {
                    string rm = folder + "\\";
                    string sheetName = name.Remove(name.IndexOf(rm), rm.Length);
                    fileList.Add(name);
                    sheetName = sheetName.Substring(0, sheetName.Length - 3);
                    GameObject result = Instantiate(templateResult, transform.position, Quaternion.identity);
                    result.GetComponent<LoadSheetFromSelector>().parent = parent;

                    if (isSheetPile)
                    {
                        result.GetComponent<LoadSheetFromSelector>().isSheetPile(pile);
                        result.GetComponent<LoadSheetFromSelector>().selector = selectionScreen;
                    }

                    resultList.Add(result);
                    fileNames.Add(sheetName);
                    result.transform.SetParent(gameObject.transform);
                    result.GetComponent<SetResultName>().setName(sheetName);
                    result.GetComponent<LoadSheetFromSelector>().sheet = sheet;
                }
            }
        }
    }
}
