using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class ListFiles : MonoBehaviour
{
    public string folder;
    public GameObject templateResult, inputContents;
    List<GameObject> resultList;
    List<string> fileNames;

    void Start()
    {
        fileNames = new List<string>();
        resultList = new List<GameObject>();
        foreach (string name in Directory.GetFiles(folder))
        {
            string rm = folder + "\\";
            string sheetName = name.Remove(name.IndexOf(rm), rm.Length);
            sheetName = sheetName.Substring(0, sheetName.Length - 3);
            GameObject result = Instantiate(templateResult, transform.position, Quaternion.identity);
            resultList.Add(result);
            fileNames.Add(sheetName);
            result.transform.SetParent(gameObject.transform);
            result.GetComponent<SetResultName>().setName(sheetName);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
